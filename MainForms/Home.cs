using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NLog;
using System.IO;

namespace OTS.Ticketing.Win.MainForms
{
    public partial class Home : Form
    {
        readonly public MainRepository mainRepository = new MainRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            RtbNotes.SelectionAlignment = HorizontalAlignment.Center;
            GetDtgLastTicketsData();
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notes.txt")))
            {
                File.CreateText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notes.txt"));
            }
            RtbNotes.Text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notes.txt"));
        }

        private async void GetDtgLastTicketsData()
        {
            try
            {
                DtgLastTickets.DataSource = SystemConstants.ToDataTable(await mainRepository.GetTodaysTickets());
                DtgLastTickets.Columns["Number"].HeaderText = "رقم البطاقة";
                DtgLastTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
                DtgLastTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
                DtgLastTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
                DtgLastTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
                DtgLastTickets.Columns["UserName"].HeaderText = "الموظف";
                DtgLastTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
                DtgLastTickets.Columns["IsIndexed"].HeaderText = "ترتيب الملفات";
                DtgLastTickets.Columns["State"].HeaderText = "الحالة";
                DtgLastTickets.Columns["Problem"].HeaderText = "المشكلة";
                DtgLastTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
                DtgLastTickets.Columns["IsClosed"].HeaderText = "الإغلاق";
                DtgLastTickets.Columns["Remarks"].HeaderText = "الملاحظات";
                DtgLastTickets.Columns["TransferedTo"].HeaderText = "تم التحويل الى";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            LblTime.Text = DateTime.Now.ToString("hh:mm:ss");
            LblDate.Text = DateTime.Now.ToString("dddd dd-MM-yyyy");
        }

        private void RtbNotes_Leave(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notes.txt"), RtbNotes.Text);
        }

        private void RtbNotes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
