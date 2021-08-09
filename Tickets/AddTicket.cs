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
        bool phoneNumberChangeFlag = false;

        public AddTicket()
        {
            InitializeComponent();
        }
        private async void AddTicket_Load(object sender, EventArgs e)
        {
            try
            {
                LblNumber.Text = await ticketRepository.GetLastTicketNumber();
                LblRevision.Text = "1";
                FillCompaniesComboBox();
                CombCompanies.Text = "";
                FillSoftwaresComboBox();
                CombSoftware.Text = "";
                FillEmployeesComboBox();
                CombEmployee.Text = "";
                FillPhoneNumbersComboBoxAndDtgUnclosedTickets();
                CombPhoneNumbers.Text = "";
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
        private async void FillPhoneNumbersComboBoxAndDtgUnclosedTickets(long selectedValue = 0)
        {
            try
            {
                if (CombCompanies.SelectedValue != null)
                {
                    bool parseOK = long.TryParse(CombCompanies.SelectedValue.ToString(), out long companyId);
                    if (parseOK)
                    {
                        var result = await ticketRepository.GetPhoneNumbersOnSelectedCompanyId(companyId);
                        if (result.Count != 0)
                        {
                            CombPhoneNumbers.DataSource = result;
                            CombPhoneNumbers.DisplayMember = "phoneNumber";
                            CombPhoneNumbers.ValueMember = "Id";
                        }
                        else CombPhoneNumbers.DataSource = null;
                        DtgUnclosedTickets.DataSource = await ticketRepository.GetUnclosedTicketsOnSelectedCompanyId(companyId);
                        DtgUnclosedTickets.Columns["Number"].HeaderText = "رقم البطاقة";
                        DtgUnclosedTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
                        DtgUnclosedTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
                        DtgUnclosedTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
                        DtgUnclosedTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
                        DtgUnclosedTickets.Columns["EmployeeName"].HeaderText = "الموظف";
                        DtgUnclosedTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
                        DtgUnclosedTickets.Columns["State"].HeaderText = "الحالة";
                        DtgUnclosedTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
                        DtgUnclosedTickets.Columns["Arrangement"].HeaderText = "ترتيب الملفات";
                        if (selectedValue != 0)
                        {
                            CombPhoneNumbers.SelectedValue = selectedValue;
                        }
                        else
                        {
                            if (result.Count != 0)
                            {
                                CombPhoneNumbers.SelectedValue = 0;
                                return;
                            }
                            CombPhoneNumbers.DataSource = null;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "FillPhoneNumbersComboBox");
            }

        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt64(CombPhoneNumbers.SelectedValue) < 1)
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
        private void CombCompanies_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CombCompanies.SelectedValue != null)
                {
                    if (phoneNumberChangeFlag)
                    {
                        phoneNumberChangeFlag = false;
                        return;
                    }
                    FillPhoneNumbersComboBoxAndDtgUnclosedTickets();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "CombCompanies_SelectedValueChanged");
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

        private void BtnAddPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                AddPhoneNumber addPhoneNumber = new AddPhoneNumber(0);
                addPhoneNumber.ShowDialog();
                FillPhoneNumbersComboBoxAndDtgUnclosedTickets();
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
                AddPhoneNumber addPhoneNumber = new AddPhoneNumber(Convert.ToInt64(CombPhoneNumbers.SelectedValue));
                addPhoneNumber.ShowDialog();
                FillPhoneNumbersComboBoxAndDtgUnclosedTickets();
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
                phoneNumberChangeFlag = true;
                DisplayPhoneNumbers displayPhoneNumbers = new DisplayPhoneNumbers(CombPhoneNumbers.Text);
                displayPhoneNumbers.ShowDialog();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
                FillPhoneNumbersComboBoxAndDtgUnclosedTickets(SystemConstants.SelectedPhoneNumberId);
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
                BtnSearchPhoneNumber_Click(sender, e);
            }
        }

    }
}
