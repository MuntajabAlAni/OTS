using OTS.Ticketing.Software.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Software.MainForms
{
    public partial class Home : Form
    {
        public MainRepository mainRepository = new MainRepository();

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            DtgLastTickets.DataSource = mainRepository.GetLastCalls();
            ColumnHeadersNaming();
        }

        private void ColumnHeadersNaming()
        {
            DtgLastTickets.Columns["Number"].HeaderText = "رقم البطاقة";
            DtgLastTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
            DtgLastTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
            DtgLastTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
            DtgLastTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
            DtgLastTickets.Columns["EmployeeName"].HeaderText = "الموظف";
            DtgLastTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
            DtgLastTickets.Columns["State"].HeaderText = "الحالة";
            DtgLastTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            LblTime.Text = DateTime.Now.ToString("hh:mm:ss");
            LblDate.Text = DateTime.Now.ToString("dddd dd-MM-yyyy");
        }
    }
}
