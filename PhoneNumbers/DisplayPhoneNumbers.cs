using NLog;
using OTS.Ticketing.Win.Enums;
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
    public partial class DisplayPhoneNumbers : Form
    {
        readonly PhoneNumberRepository phoneNumberRepository = new PhoneNumberRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        readonly private string _phoneNumber;
        readonly bool _search;

        public DisplayPhoneNumbers(bool search, string phoneNumber = "")
        {
            InitializeComponent();
            _phoneNumber = phoneNumber;
            _search = search;
        }

        private async void DisplayPhoneNumbers_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.AddPhoneNumber)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAdd.Visible = false;
                await GetDtgPhoneNumbersData();
                if (_search)
                {
                    BtnAdd.Visible = false;
                    if (DtgPhoneNumbers.Rows.Count == 1)
                    {
                        long id = Convert.ToInt64(DtgPhoneNumbers.Rows[0].Cells["Id"].Value.ToString());
                        PhoneNumberInfo selectedPhoneNumber = await phoneNumberRepository.GetById(id);
                        SystemConstants.selectedPhoneNumberId = selectedPhoneNumber.Id;
                        SystemConstants.selectedCompanyId = selectedPhoneNumber.CompanyId;
                        this.Close();
                    }
                    if (DtgPhoneNumbers.Rows.Count == 0)
                    {
                        MessageBox.Show("عذراً.. هذا الرقم غير معرف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        AddPhoneNumber addPhoneNumber = new AddPhoneNumber(0, _phoneNumber);
                        addPhoneNumber.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async Task GetDtgPhoneNumbersData()
        {
            DataTable dt = SystemConstants.ToDataTable(await phoneNumberRepository.GetBySearch(_phoneNumber));
            DataColumn dc = new DataColumn("ت", typeof(int));
            dt.Columns.Add(dc);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dr["ت"] = i + 1;
                i++;
            }
            DtgPhoneNumbers.DataSource = dt;
            DtgPhoneNumbers.Columns["ت"].DisplayIndex = 0;
            DtgPhoneNumbers.Columns["Id"].Visible = false;
            DtgPhoneNumbers.Columns["phoneNumber"].HeaderText = "رقم الهاتف";
            DtgPhoneNumbers.Columns["CustomerName"].HeaderText = "اسم الزبون";
            DtgPhoneNumbers.Columns["CompanyName"].HeaderText = "اسم الشركة";
            DtgPhoneNumbers.Columns["IsDeleted"].Visible = false;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayPhoneNumbers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            AddPhoneNumber addPhoneNumber = new AddPhoneNumber(0);
            addPhoneNumber.ShowDialog();
            await GetDtgPhoneNumbersData();
        }

        private async void DtgPhoneNumbers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_search)
                {

                    long id = Convert.ToInt64(DtgPhoneNumbers.SelectedRows[0].Cells["Id"].Value.ToString());
                    PhoneNumberInfo selectedPhoneNumber = await phoneNumberRepository.GetById(id);
                    SystemConstants.selectedPhoneNumberId = selectedPhoneNumber.Id;
                    SystemConstants.selectedCompanyId = selectedPhoneNumber.CompanyId;
                    this.Close();
                }
                else
                {
                    if (!SystemConstants.userRoles.Contains(((long)RoleType.EditPhoneNumber)) &
                        !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                        return;
                    long id = Convert.ToInt64(DtgPhoneNumbers.SelectedRows[0].Cells["Id"].Value.ToString());
                    AddPhoneNumber addPhoneNumber = new AddPhoneNumber(id);
                    addPhoneNumber.ShowDialog();
                    await GetDtgPhoneNumbersData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
    }
}
