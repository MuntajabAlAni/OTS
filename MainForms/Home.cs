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

namespace OTS.Ticketing.Win.MainForms
{
    public partial class Home : Form
    {
        readonly public MainRepository mainRepository = new MainRepository();

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            GetDtgLastTicketsData();
        }

        private async void GetDtgLastTicketsData()
        {
            try
            {
                DtgLastTickets.DataSource = await mainRepository.GetLastFiveCalls();
                DtgLastTickets.Columns["Number"].HeaderText = "رقم البطاقة";
                DtgLastTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
                DtgLastTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
                DtgLastTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
                DtgLastTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
                DtgLastTickets.Columns["EmployeeName"].HeaderText = "الموظف";
                DtgLastTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
                DtgLastTickets.Columns["Arrangement"].HeaderText = "ترتيب الملفات";
                DtgLastTickets.Columns["State"].HeaderText = "الحالة";
                DtgLastTickets.Columns["Problem"].HeaderText = "المشكلة";
                DtgLastTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
                DtgLastTickets.Columns["IsClosed"].HeaderText = "الإغلاق";
                DtgLastTickets.Columns["Remarks"].HeaderText = "الملاحظات";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetDtgLastTicketsData");
            }

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            LblTime.Text = DateTime.Now.ToString("hh:mm:ss");
            LblDate.Text = DateTime.Now.ToString("dddd dd-MM-yyyy");
        }
    }
}
