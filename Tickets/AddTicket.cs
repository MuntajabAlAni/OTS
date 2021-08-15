using NLog;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.Employees;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Softwares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class AddTicket : Form
    {
        readonly TicketRepository ticketRepository = new TicketRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public AddTicket()
        {
            InitializeComponent();
        }
        private async void AddTicket_Load(object sender, EventArgs e)
        {
            try
            {
                var employeeInfo = await ticketRepository.GetEmployeeById(SystemConstants.loggedInEmployeeId);
                if (employeeInfo.UserName != "admin")
                {
                    BtnAddEmployee.Visible = false;
                    BtnEditEmployee.Visible = false;
                    BtnAddSoftware.Visible = false;
                    BtnEditSoftware.Visible = false;
                }
                LblNumber.Text = await ticketRepository.GetLastTicketNumber();
                LblRevision.Text = "0";
                FillCompaniesComboBox();
                FillSoftwaresComboBox();
                FillEmployeesComboBox();
                FillPhoneNumbersComboBox();
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
                CombCompanies.DataSource = await ticketRepository.GetAllCompanies();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillSoftwaresComboBox()
        {
            try
            {
                CombSoftware.DisplayMember = "Name";
                CombSoftware.ValueMember = "Id";
                CombSoftware.DataSource = await ticketRepository.GetAllSoftwares();
                CombSoftware.SelectedValue = SystemConstants.SelectedSoftware;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillEmployeesComboBox()
        {
            try
            {
                CombEmployee.DisplayMember = "displayName";
                CombEmployee.ValueMember = "Id";
                CombEmployee.DataSource = await ticketRepository.GetAllEmployees();
                CombEmployee.SelectedValue = SystemConstants.SelectedEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillPhoneNumbersComboBox()
        {
            try
            {
                //companyId = CombCompanies.SelectedValue != null ? Convert.ToInt64(CombCompanies.SelectedValue) : 0;
                var result = await ticketRepository.GetPhoneNumbersOnSelectedCompanyId(Convert.ToInt64(CombCompanies.SelectedValue));
                if (result.Count != 0)
                {
                    CombPhoneNumbers.DisplayMember = "phoneNumber";
                    CombPhoneNumbers.ValueMember = "Id";
                    CombPhoneNumbers.DataSource = result;
                    CombPhoneNumbers.SelectedValue = SystemConstants.SelectedPhoneNumberId;
                }
                else CombPhoneNumbers.DataSource = null;
                FillDtgUnclosedTickets(Convert.ToInt64(CombCompanies.SelectedValue));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillDtgUnclosedTickets(long companyId)
        {
            DtgUnclosedTickets.DataSource = await ticketRepository.GetUnclosedTicketsOnSelectedCompanyId(companyId);
            DtgUnclosedTickets.Columns["Number"].HeaderText = "رقم البطاقة";
            DtgUnclosedTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
            DtgUnclosedTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
            DtgUnclosedTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
            DtgUnclosedTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
            DtgUnclosedTickets.Columns["EmployeeName"].HeaderText = "الموظف";
            DtgUnclosedTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
            DtgUnclosedTickets.Columns["Problem"].HeaderText = "المشكلة";
            DtgUnclosedTickets.Columns["State"].HeaderText = "الحالة";
            DtgUnclosedTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
            DtgUnclosedTickets.Columns["Arrangement"].HeaderText = "ترتيب الملفات";
            DtgUnclosedTickets.Columns["IsClosed"].HeaderText = "الإغلاق";
            DtgUnclosedTickets.Columns["Remarks"].Visible = false;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt64(CombPhoneNumbers.SelectedValue) == 0
                    | Convert.ToInt64(CombCompanies.SelectedValue) == 0
                    | Convert.ToInt64(CombEmployee.SelectedValue) == 0
                    | Convert.ToInt64(CombSoftware.SelectedValue) == 0)
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr;
                dr = MessageBox.Show("هل انت متأكد من الإضافة ؟", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    await ticketRepository.AddTicket(Convert.ToInt64(LblNumber.Text),
                Convert.ToInt32(LblRevision.Text),
                Convert.ToInt64(CombCompanies.SelectedValue),
                Convert.ToInt64(CombPhoneNumbers.SelectedValue),
                Convert.ToInt64(CombSoftware.SelectedValue),
                Convert.ToInt64(CombEmployee.SelectedValue));
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void DtgUnclosedTickets_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                long selectedNumber = Convert.ToInt64(DtgUnclosedTickets.SelectedRows[0].Cells["Number"].Value.ToString());
                long selectedRevision = Convert.ToInt64(DtgUnclosedTickets.SelectedRows[0].Cells["Revision"].Value.ToString());
                TicketInfo selectedTicket = await ticketRepository.GetTicketByNumberAndRevision(selectedNumber, selectedRevision);
                LblNumber.Text = selectedTicket.Number.ToString();
                LblRevision.Text = (selectedTicket.Revision + 1).ToString();
                CombCompanies.SelectedValue = selectedTicket.CompanyId;
                CombEmployee.SelectedValue = selectedTicket.EmployeeId;
                CombPhoneNumbers.SelectedValue = selectedTicket.PhoneNumberId;
                CombSoftware.SelectedValue = selectedTicket.SoftwareId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                AddCompany addCompany = new AddCompany(0);
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
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnAddPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.SelectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
                AddPhoneNumber addPhoneNumber = new AddPhoneNumber(0, CombPhoneNumbers.Text);
                addPhoneNumber.ShowDialog();
                FillCompaniesComboBox();
                FillPhoneNumbersComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnEditPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.SelectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
                AddPhoneNumber addPhoneNumber = new AddPhoneNumber(Convert.ToInt64(CombPhoneNumbers.SelectedValue), CombPhoneNumbers.Text);
                addPhoneNumber.ShowDialog();
                FillCompaniesComboBox();
                FillPhoneNumbersComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void BtnSearchPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.SelectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
                DisplayPhoneNumbers displayPhoneNumbers = new DisplayPhoneNumbers(CombPhoneNumbers.Text);
                displayPhoneNumbers.ShowDialog();
                FillCompaniesComboBox();
                FillPhoneNumbersComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void CombPhoneNumbers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (!(CombPhoneNumbers.Text == "") & CombPhoneNumbers.Text.Length < 11)
                {
                    MessageBox.Show("يرجى ادخال الرقم كاملاً");
                    CombPhoneNumbers.Focus();
                    return;
                }
                BtnSearchPhoneNumber_Click(sender, e);
            }
        }
        private void CombPhoneNumbers_Leave(object sender, EventArgs e)
        {
            if (!(CombPhoneNumbers.Text == "") & CombPhoneNumbers.Text.Length < 11)
            {
                MessageBox.Show("يرجى ادخال الرقم كاملاً");
                CombPhoneNumbers.Focus();
            }
        }
        private void BtnSearchCompany_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayCompanies displayCompanies = new DisplayCompanies(CombCompanies.Text);
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
        private void BtnAddSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                AddSoftware addSoftware = new AddSoftware(0);
                addSoftware.ShowDialog();
                FillSoftwaresComboBox();
                CombSoftware.SelectedValue = SystemConstants.SelectedSoftware;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnEditSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                AddSoftware addSoftware = new AddSoftware(Convert.ToInt64(CombSoftware.SelectedValue));
                addSoftware.ShowDialog();
                FillSoftwaresComboBox();
                CombSoftware.SelectedValue = SystemConstants.SelectedSoftware;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                AddEmployee addEmployee = new AddEmployee(0);
                addEmployee.ShowDialog();
                FillEmployeesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnEditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                AddEmployee addEmployee = new AddEmployee(Convert.ToInt64(CombEmployee.SelectedValue));
                addEmployee.ShowDialog();
                FillEmployeesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void CombCompanies_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CombCompanies.SelectedValue != null)
                {
                    FillPhoneNumbersComboBox();
                    FillDtgUnclosedTickets(Convert.ToInt64(CombCompanies.SelectedValue));
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
