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

namespace OTS.Ticketing.Win.Tickets
{
    public partial class DisplayTickets : Form
    {
        public TicketRepository ticketRepository = new TicketRepository();
        public DisplayTickets()
        {
            InitializeComponent();
        }

        private void DisplayTickets_Load(object sender, EventArgs e)
        {

           
            DtgTickets.DataSource = ticketRepository.GetAllTickets();
            ColumnHeadersNaming();
            TxtNumber.Text = ticketRepository.GetLastTicketNumber();
            DtpStartDate.Value = DateTime.Now;
            FillCompaniesComboBox();
            FillSoftwaresComboBox();
            FillEmployeesComboBox();
            FillStatesComboBox();
        }

        private void FillCompaniesComboBox()
        {
            CombCompanies.DataSource = ticketRepository.GetAllCompanies();
            CombCompanies.DisplayMember = "Name";
            CombCompanies.ValueMember = "Id";
        }
        private void FillSoftwaresComboBox()
        {
            CombSoftware.DataSource = ticketRepository.GetAllSoftwares();
            CombSoftware.DisplayMember = "Name";
            CombSoftware.ValueMember = "Id";
        }
        private void FillEmployeesComboBox()
        {
            CombEmployee.DataSource = ticketRepository.GetAllEmployees();
            CombEmployee.DisplayMember = "displayName";
            CombEmployee.ValueMember = "Id";
        }
        private void FillStatesComboBox()
        {
            CombState.DataSource = ticketRepository.GetAllStates();
            CombState.DisplayMember = "Name";
            CombState.ValueMember = "Id";
        }
        private void ColumnHeadersNaming()
        {
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
    }
}
