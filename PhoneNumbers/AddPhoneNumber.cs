using OTS.Ticketing.Win.Companies;
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
        private readonly long _id;
        private readonly string _phoneNumber;
        private readonly long _companyId;

        public AddPhoneNumber(long id,string phoneNumber = "",long companyId = 0)
        {
            InitializeComponent();
            _id = id;
            _phoneNumber = phoneNumber;
            _companyId = companyId;
        }
        private async void AddPhoneNumber_Load(object sender, EventArgs e)
        {
            try
            {
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
                SystemConstants.ErrorLog(ex, "AddPhoneNumber_Load");
            }

        }
        private async void FillCompaniesComboBox()
        {
            try
            {
                CombCompanies.DataSource = await phoneNumberRepository.GetAllCompanies();
                CombCompanies.DisplayMember = "Name";
                CombCompanies.ValueMember = "Id";
                TxtPhoneNumber.Text = _phoneNumber;
                CombCompanies.SelectedValue = _companyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "FillCompaniesComboBox");
            }

        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtPhoneNumber.Text == "" | CombCompanies.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_id == 0)
                {
                    await phoneNumberRepository.AddPhoneNumber(TxtPhoneNumber.Text,
                        TxtCustomerName.Text,
                        Convert.ToInt64(CombCompanies.SelectedValue));
                }
                else
                {
                    await phoneNumberRepository.UpdatePhoneNumber(_id,
                        TxtPhoneNumber.Text,
                        TxtCustomerName.Text,
                        Convert.ToInt64(CombCompanies.SelectedValue));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnAdd_Click");
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
                AddCompany addCompany = new AddCompany(0);
                addCompany.ShowDialog();
                FillCompaniesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnAddCompany_Click");
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
                SystemConstants.ErrorLog(ex, "BtnEditCompany_Click");
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
    }
}
