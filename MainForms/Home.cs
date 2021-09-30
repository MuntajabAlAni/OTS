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
using OTS.Ticketing.Win.Users;

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
            GetDtgUsersData();
        }
        private async void GetDtgLastTicketsData()
        {
            try
            {
                DtgLastTickets.DataSource = SystemConstants.ToDataTable(await mainRepository.GetTodaysTickets());
                DtgLastTickets.Columns["Number"].HeaderText = LocalizationMessages.GetMessage("Number");
                DtgLastTickets.Columns["OpenDate"].HeaderText = LocalizationMessages.GetMessage("OpenDate");
                DtgLastTickets.Columns["CloseDate"].HeaderText = LocalizationMessages.GetMessage("CloseDate");
                DtgLastTickets.Columns["PhoneNumber"].HeaderText = LocalizationMessages.GetMessage("PhoneNumber");
                DtgLastTickets.Columns["SoftwareName"].HeaderText = LocalizationMessages.GetMessage("SoftwareName");
                DtgLastTickets.Columns["UserName"].HeaderText = LocalizationMessages.GetMessage("UserName");
                DtgLastTickets.Columns["CompanyName"].HeaderText = LocalizationMessages.GetMessage("CompanyName");
                DtgLastTickets.Columns["BranchName"].HeaderText = LocalizationMessages.GetMessage("BranchName");
                DtgLastTickets.Columns["IsIndexed"].HeaderText = LocalizationMessages.GetMessage("IsIndexed");
                DtgLastTickets.Columns["State"].HeaderText = LocalizationMessages.GetMessage("State");
                DtgLastTickets.Columns["Problem"].HeaderText = LocalizationMessages.GetMessage("Problem");
                DtgLastTickets.Columns["Revision"].HeaderText = LocalizationMessages.GetMessage("Revision");
                DtgLastTickets.Columns["IsClosed"].HeaderText = LocalizationMessages.GetMessage("IsClosed");
                DtgLastTickets.Columns["Remarks"].HeaderText = LocalizationMessages.GetMessage("Remarks");
                DtgLastTickets.Columns["TransferedTo"].HeaderText = LocalizationMessages.GetMessage("TransferedTo");
                DtgLastTickets.Columns["IsDeleted"].Visible = false;

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
        private void GetDtgUsersData()
        {
            Task.Run(async () =>
    {
        while (true)
        {

            DataTable dt = SystemConstants.ToDataTable(await mainRepository.GetAllUsers());
            dt.Columns.Remove("id");
            dt.Columns.Remove("UserName");
            dt.Columns.Remove("password");
            dt.Columns.Remove("state");
            dt.Columns.Remove("ip");
            dt.Columns.Remove("remarks");
            dt.Columns.Remove("salt");
            dt.Columns.Remove("isDeleted");
            dt.Columns["displayName"].ColumnName = "اسم المستخدم";
            dt.Columns["Number"].ColumnName = "الرقم";

            this.Invoke((MethodInvoker)delegate
            {
                DtgUsers.DataSource = dt;
                DtgUsers.Columns["isOnline"].Visible = false;

                Image online = Image.FromFile(Directory.GetCurrentDirectory() + "\\Wake.png");
                Image offline = Image.FromFile(Directory.GetCurrentDirectory() + "\\Sleep.png");

                if (DtgUsers.Columns.Contains("الحالة") == false)
                {
                    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                    DtgUsers.Columns.Add(imageCol);
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.HeaderText = "الحالة";
                    imageCol.Name = "الحالة";
                }

                foreach (DataGridViewRow row in DtgUsers.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["isOnline"].Value) == true)
                    {
                        row.Cells["الحالة"].Value = online;
                    }
                    else
                    {
                        row.Cells["الحالة"].Value = offline;
                    }
                }
                foreach (DataGridViewColumn col in DtgUsers.Columns)
                {
                    DtgUsers.Columns[col.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            });
            await Task.Delay(5000);
        }

    });

        }
        private void RtbNotes_Leave(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notes.txt"), RtbNotes.Text);
        }
        private async void BtnOnlineState_Click(object sender, EventArgs e)
        {
            if (BtnOnlineState.Text == "مشغول")
            {
                await mainRepository.UpdateIsOnlineByUserId(false, SystemConstants.loggedInUserId);
                BtnOnlineState.Text = "متفرغ";
            }
            else if (BtnOnlineState.Text == "متفرغ")
            {
                await mainRepository.UpdateIsOnlineByUserId(true, SystemConstants.loggedInUserId);
                BtnOnlineState.Text = "مشغول";
            }
        }
        private void DtgUsers_SelectionChanged(object sender, EventArgs e)
        {
            DtgUsers.ClearSelection();
        }
    }
}
