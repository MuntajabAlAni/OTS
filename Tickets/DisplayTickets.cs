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
            CombCompaies.DataSource = await ticketRepository.GetAllCompanies();
            CombCompaies.DisplayMember = "Name";
            CombCompaies.ValueMember = "Id";
        }
        private async void FillSoftwaresComboBox()
        {
            CombSoftwares.DataSource = await ticketRepository.GetAllSoftwares();
            CombSoftwares.DisplayMember = "Name";
            CombSoftwares.ValueMember = "Id";
        }
        private async void FillEmployeesComboBox()
        {
            CombEmployees.DataSource = await ticketRepository.GetAllEmployees();
            CombEmployees.DisplayMember = "displayName";
            CombEmployees.ValueMember = "Id";
        }
        private async void FillStatesComboBox()
        {
            CombStates.DataSource = await ticketRepository.GetAllStates();
            CombStates.DisplayMember = "Name";
            CombStates.ValueMember = "Id";
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
            LblNumber.Text = selectedTicket.Number.ToString();
            LblRevision.Text = selectedTicket.Revision.ToString();
            CombCompaies.SelectedValue = selectedTicket.CompanyId;
            CombEmployees.SelectedValue = selectedTicket.EmployeeId;
            CombPhoneNumbers.SelectedValue = selectedTicket.PhoneNumberId;
            CombSoftwares.SelectedValue = selectedTicket.SoftwareId;
            DtpOpenDate.Value = selectedTicket.OpenDate;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DtpCloseDate.Value = DateTime.Now;
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
                await ticketRepository.UpdateTicket(Convert.ToInt64(LblNumber.Text),
                Convert.ToInt32(LblRevision.Text),
                DtpCloseDate.Value,
                Convert.ToInt64(CombStates.SelectedValue),
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
