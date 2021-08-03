using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Software.Tickets
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

    }
}
