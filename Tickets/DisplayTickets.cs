using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OTS.Ticketing.Win.MainForms;
using OTS.Ticketing.Win.States;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class DisplayTickets : Form
    {
        readonly TicketRepository ticketRepository = new TicketRepository();
        public DisplayTickets()
        {
            InitializeComponent();
        }

        private void DisplayTickets_Load(object sender, EventArgs e)
        {
            GetDtgTicketsData();
            FillCompaniesComboBox();
            FillSoftwaresComboBox();
            FillEmployeesComboBox();
            FillStatesComboBox();
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
        private async void FillStatesComboBox()
        {
            CombState.DataSource = await ticketRepository.GetAllStates();
            CombState.DisplayMember = "Name";
            CombState.ValueMember = "Id";
        }
        private async void FillPhoneNumbersComboBox()
        {

            CombPhoneNumbers.DataSource = await ticketRepository.GetPhoneNumbersOnSelectedCompanyId(0);
            CombPhoneNumbers.DisplayMember = "phoneNumber";
            CombPhoneNumbers.ValueMember = "Id";
        }
        private async void GetDtgTicketsData()
        {
            DtgTickets.DataSource = await ticketRepository.GetAllTicketsByEmployeeId(SystemConstants.loggedInEmployeeId);
            DtgTickets.Columns["Number"].HeaderText = "رقم البطاقة";
            DtgTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
            DtgTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
            DtgTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
            DtgTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
            DtgTickets.Columns["EmployeeName"].HeaderText = "الموظف";
            DtgTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
            DtgTickets.Columns["State"].HeaderText = "الحالة";
            DtgTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
        }


        private void ToggleRemotely_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (ToggleRemotely.Checked) LblRemote.Text = "بإستخدام Anydesk";
            else LblRemote.Text = "بإتصال فقط";
        }

        private async void DtgTickets_DoubleClick(object sender, EventArgs e)
        {
            long selectedNumber = Convert.ToInt64(DtgTickets.SelectedRows[0].Cells["Number"].Value.ToString());
            long selectedRevision = Convert.ToInt64(DtgTickets.SelectedRows[0].Cells["Revision"].Value.ToString());
            TicketInfo selectedTicket = await ticketRepository.GetTicketByNumberAndRevision(selectedNumber, selectedRevision);
            TxtNumber.Text = selectedTicket.Number.ToString();
            TxtRevision.Text = selectedTicket.Revision.ToString();
            CombCompanies.SelectedValue = selectedTicket.CompanyId;
            CombEmployee.SelectedValue = selectedTicket.EmployeeId;
            CombPhoneNumbers.SelectedValue = selectedTicket.PhoneNumberId;
            CombSoftware.SelectedValue = selectedTicket.SoftwareId;
            DtpOpenDate.Value = selectedTicket.OpenDate;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DtpCloseDate.Value = DateTime.Now;
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            await ticketRepository.UpdateTicket(Convert.ToInt64(TxtNumber.Text),
                Convert.ToInt32(TxtRevision.Text),
                DtpCloseDate.Value,
                Convert.ToInt64(CombState.SelectedValue),
                TxtRemarks.Text,
                ToggleRemotely.Checked);
            GetDtgTicketsData();
        }

        private void BtnAddState_Click(object sender, EventArgs e)
        {
            AddState addState = new AddState();
            addState.ShowDialog();
            FillStatesComboBox();
        }
    }
}
