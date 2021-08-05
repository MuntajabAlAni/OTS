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
            LblNumber.Text = await ticketRepository.GetLastTicketNumber();
            LblRevision.Text = "1";
            FillCompaniesComboBox();
            FillSoftwaresComboBox();
            FillEmployeesComboBox();
            FillPhoneNumbersComboBox();
        }
        private async void FillCompaniesComboBox()
        {
            CombCompanies.DataSource = await ticketRepository.GetAllCompanies();
            CombCompanies.DisplayMember = "Name";
            CombCompanies.ValueMember = "Id";
        }
        private async void FillSoftwaresComboBox()
        {
            CombSoftware.DataSource = await ticketRepository.GetAllSoftwares();
            CombSoftware.DisplayMember = "Name";
            CombSoftware.ValueMember = "Id";
        }
        private async void FillEmployeesComboBox()
        {
            CombEmployee.DataSource = await ticketRepository.GetAllEmployees();
            CombEmployee.DisplayMember = "displayName";
            CombEmployee.ValueMember = "Id";
        }
        private async void FillPhoneNumbersComboBox()
        {
            if (CombCompanies.SelectedValue != null)
            {
                bool parseOK = long.TryParse(CombCompanies.SelectedValue.ToString(), out long companyId);
                if (parseOK)
                {
                    CombPhoneNumbers.DataSource = await ticketRepository.GetPhoneNumbersOnSelectedCompanyId(companyId);
                    CombPhoneNumbers.DisplayMember = "phoneNumber";
                    CombPhoneNumbers.ValueMember = "Id";
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
                }
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            await ticketRepository.AddTicket(Convert.ToInt64(LblNumber.Text),
                Convert.ToInt32(LblRevision.Text),
                Convert.ToInt64(CombCompanies.SelectedValue),
                Convert.ToInt64(CombPhoneNumbers.SelectedValue),
                Convert.ToInt64(CombSoftware.SelectedValue),
                Convert.ToInt64(CombEmployee.SelectedValue));
            this.Close();
        }

        private void CombCompanies_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CombCompanies.SelectedValue != null)
            {
                FillPhoneNumbersComboBox();
            }
        }

        private async void DtgUnclosedTickets_DoubleClick(object sender, EventArgs e)
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
    }
}
