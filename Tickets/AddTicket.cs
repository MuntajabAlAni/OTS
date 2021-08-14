using OTS.Ticketing.Win.Companies;
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

        public AddTicket()
        {
            InitializeComponent();
        }
        private async void AddTicket_Load(object sender, EventArgs e)
        {
            try
            {
                LblNumber.Text = await ticketRepository.GetLastTicketNumber();
                LblRevision.Text = "0";
                FillCompaniesComboBox();
                FillSoftwaresComboBox();
                FillEmployeesComboBox();
                FillPhoneNumbersComboBox(true);
                SelectDefaultValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "AddTicket_Load");
            }

        }
        private async void FillCompaniesComboBox()
        {
            try
            {
                CombCompanies.DataSource = await ticketRepository.GetAllCompanies();
                CombCompanies.DisplayMember = "Name";
                CombCompanies.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "FillCompaniesComboBox");
            }

        }
        private async void FillSoftwaresComboBox()
        {
            try
            {
                CombSoftware.DataSource = await ticketRepository.GetAllSoftwares();
                CombSoftware.DisplayMember = "Name";
                CombSoftware.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "FillSoftwaresComboBox");
            }

        }
        private async void FillEmployeesComboBox()
        {
            try
            {
                CombEmployee.DataSource = await ticketRepository.GetAllEmployees();
                CombEmployee.DisplayMember = "displayName";
                CombEmployee.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "FillEmployeesComboBox");
            }

        }
        private async void FillPhoneNumbersComboBox(bool allCompanies = false)
        {
            try
            {
                if (allCompanies)
                {
                    var allResults = await ticketRepository.GetPhoneNumbersOnSelectedCompanyId(0);
                    if (allResults.Count != 0)
                    {
                        CombPhoneNumbers.DataSource = allResults;
                        CombPhoneNumbers.DisplayMember = "phoneNumber";
                        CombPhoneNumbers.ValueMember = "Id";
                        CombPhoneNumbers.SelectedIndex = 0;
                        return;
                    }
                }
                else if (CombCompanies.SelectedValue != null)
                {
                    bool parseOK = long.TryParse(CombCompanies.SelectedValue.ToString(), out long selectedcompanyId);
                    if (parseOK)
                    {
                        var result = await ticketRepository.GetPhoneNumbersOnSelectedCompanyId(selectedcompanyId);
                        if (result.Count != 0)
                        {
                            CombPhoneNumbers.DataSource = result;
                            CombPhoneNumbers.DisplayMember = "phoneNumber";
                            CombPhoneNumbers.ValueMember = "Id";
                            CombPhoneNumbers.SelectedValue = SystemConstants.SelectedPhoneNumberId;
                        }
                        else CombPhoneNumbers.DataSource = null;
                        FillDtgUnclosedTickets(Convert.ToInt64(CombCompanies.SelectedValue));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "FillPhoneNumbersComboBox");
            }

        }
        private void SelectDefaultValues()
        {
            CombCompanies.SelectedValue = 0;
            CombSoftware.SelectedValue = 0;
            CombEmployee.SelectedValue = 0;
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
                SystemConstants.ErrorLog(ex, "BtnAdd_Click");
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
                SystemConstants.ErrorLog(ex, "DtgUnclosedTickets_DoubleClick");
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
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnEditCompany_Click");
            }
        }
        private void BtnAddPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                AddPhoneNumber addPhoneNumber = new AddPhoneNumber(0, CombPhoneNumbers.Text, Convert.ToInt64(CombCompanies.SelectedValue));
                addPhoneNumber.ShowDialog();
                FillCompaniesComboBox();
                FillPhoneNumbersComboBox();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
                CombPhoneNumbers.SelectedValue = SystemConstants.SelectedPhoneNumberId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnAddPhoneNumber_Click");
            }
        }
        private void BtnEditPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                AddPhoneNumber addPhoneNumber = new AddPhoneNumber(Convert.ToInt64(CombPhoneNumbers.SelectedValue), CombPhoneNumbers.Text, Convert.ToInt64(CombCompanies.SelectedValue));
                addPhoneNumber.ShowDialog();
                FillPhoneNumbersComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnEditPhoneNumber_Click");
            }

        }
        private void BtnSearchPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayPhoneNumbers displayPhoneNumbers = new DisplayPhoneNumbers(CombPhoneNumbers.Text, Convert.ToInt64(CombCompanies.SelectedValue));
                displayPhoneNumbers.ShowDialog();
                FillCompaniesComboBox();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
                FillPhoneNumbersComboBox();
                CombPhoneNumbers.SelectedValue = SystemConstants.SelectedPhoneNumberId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnSearchPhoneNumber_Click");
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
        private void CombCompanies_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CombCompanies.SelectedValue != null)
                {
                    bool parseOK = long.TryParse(CombCompanies.SelectedValue.ToString(), out long companyId);
                    if (parseOK)
                    {
                        FillPhoneNumbersComboBox();
                        FillDtgUnclosedTickets(companyId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "CombCompanies_SelectedValueChanged");
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
                SystemConstants.ErrorLog(ex, "BtnSearchPhoneNumber_Click");
            }
        }

        private void CombCompanies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                BtnSearchCompany_Click(sender, e);
            }
        }
    }
}
