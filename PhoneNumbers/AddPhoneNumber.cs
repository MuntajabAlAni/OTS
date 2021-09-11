using NLog;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.PhoneNumbers
{
    public partial class AddPhoneNumber : Form
    {
        readonly PhoneNumberRepository phoneNumberRepository = new PhoneNumberRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly long _id;
        private readonly string _phoneNumber;

        public AddPhoneNumber(long id, string phoneNumber = "")
        {
            InitializeComponent();
            _id = id;
            _phoneNumber = phoneNumber;
        }
        private async void AddPhoneNumber_Load(object sender, EventArgs e)
        {
            try
            {
                if (_phoneNumber != "")
                {
                    TxtPhoneNumber.Text = _phoneNumber;
                }
                FillCompaniesComboBox();
                if (_id != 0)
                {
                    PhoneNumberInfo phoneNumberInfo = await phoneNumberRepository.GetPhoneNumberById(_id);
                    TxtPhoneNumber.Text = phoneNumberInfo.PhoneNumber;
                    TxtCustomerName.Text = phoneNumberInfo.CustomerName;
                    CombCompanies.SelectedValue = phoneNumberInfo.CompanyId;
                    BtnAdd.Text = "تعديل";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillCompaniesComboBox()
        {
            try
            {
                CombCompanies.DisplayMember = "Name";
                CombCompanies.ValueMember = "Id";
                CombCompanies.DataSource = await phoneNumberRepository.GetAllCompanies();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtPhoneNumber.Text == "" | CombCompanies.SelectedValue == DBNull.Value | Convert.ToInt64(CombCompanies.SelectedValue) == 0)
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_id == 0)
                {
                    await phoneNumberRepository.AddPhoneNumber(TxtPhoneNumber.Text,
                        TxtCustomerName.Text,
                        Convert.ToInt64(CombCompanies.SelectedValue));
                    await ActivityLogUtility.ActivityLog(Enums.Activities.AddPhoneNumber, "إضافة رقم هاتف",
                        await phoneNumberRepository.GetLastAddedPhoneNumberId());
                }
                else
                {
                    await phoneNumberRepository.UpdatePhoneNumber(_id,
                        TxtPhoneNumber.Text,
                        TxtCustomerName.Text,
                        Convert.ToInt64(CombCompanies.SelectedValue));
                    await ActivityLogUtility.ActivityLog(Enums.Activities.EditPhoneNumber, "تعديل رقم هاتف", _id);

                }
                SystemConstants.SelectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
                SystemConstants.SelectedPhoneNumberId = await phoneNumberRepository.GetPhoneNumberIdByPhoneNumber(TxtPhoneNumber.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                AddCompany addCompany = new AddCompany(0, CombCompanies.Text);
                addCompany.ShowDialog();
                FillCompaniesComboBox();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void BtnEditCompany_Click(object sender, EventArgs e)
        {
            try
            {
                AddCompany addCompany = new AddCompany(Convert.ToInt64(CombCompanies.SelectedValue));
                addCompany.ShowDialog();
                FillCompaniesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void AddPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
        private void TxtPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (!(TxtPhoneNumber.Text == "") & TxtPhoneNumber.Text.Length < 11)
            {
                MessageBox.Show("يرجى ادخال الرقم كاملاً");
                TxtPhoneNumber.Focus();
            }
        }
        private void BtnSearchCompany_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayCompanies displayCompanies = new DisplayCompanies(true, CombCompanies.Text);
                displayCompanies.ShowDialog();
                FillCompaniesComboBox();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void CombCompanies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                BtnSearchCompany_Click(sender, e);
            }
        }

        private void TxtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
