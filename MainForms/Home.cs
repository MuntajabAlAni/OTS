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
using OTS.Ticketing.Win.Tickets;

namespace OTS.Ticketing.Win.MainForms
{
    public partial class Home : Form
    {
        public readonly MainRepository _mainRepository;
        public readonly TicketRepository _ticketRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public Home()
        {
            _mainRepository = new MainRepository();
            _ticketRepository = new TicketRepository();
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            try
            {
                if (SystemConstants.loggedInUser.Id != 1 & SystemConstants.loggedInUser.Id != 2)
                {
                    BtnOnlineState.Visible = true;
                }
                RtbNotes.SelectionAlignment = HorizontalAlignment.Center;
                GetDtgLastTicketsData();
                if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notes.txt")))
                {
                    File.CreateText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notes.txt"));
                }
                RtbNotes.Text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notes.txt"));
                GetDtgUsersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void GetDtgLastTicketsData()
        {
            try
            {
                DtgLastTickets.DataSource = SystemConstants.ToDataTable(await _ticketRepository.GetTodaysTickets());
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
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            Task.Run(async () =>
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                DataTable dt = SystemConstants.ToDataTable(await _mainRepository.GetSessions());
                dt.Columns.Remove("id");
                dt.Columns.Remove("userId");
                dt.Columns.Remove("computerName");
                dt.Columns.Remove("lastUpdateDate");
                dt.Columns.Remove("SessionId");
                dt.Columns["displayName"].ColumnName = "اسم المستخدم";
                dt.Columns["EventName"].ColumnName = "اخر حركة";
                dt.Columns["Number"].ColumnName = "الرقم";

                DtgUsers.Invoke(() =>
                {

                    DtgUsers.DataSource = dt;
                    DtgUsers.Sort(DtgUsers.Columns["isOnline"], System.ComponentModel.ListSortDirection.Descending);
                    DtgUsers.Columns["isOnline"].Visible = false;
                    Image online = Properties.Resources.GreenCircle;
                    Image offline = Properties.Resources.RedCircle;

                    if (DtgUsers.Columns.Contains("الحالة") == false)
                    {
                        DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                        DtgUsers.Columns.Add(imageCol);
                        imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        imageCol.HeaderText = "الحالة";
                        imageCol.Name = "الحالة";
                        imageCol.DisplayIndex = 0;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
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
                await _mainRepository.UpdateIsOnlineByUserId(false, SystemConstants.loggedInUser.Id);
                BtnOnlineState.Text = "متفرغ";
                BtnOnlineState.BackColor = Color.Crimson;
            }
            else if (BtnOnlineState.Text == "متفرغ")
            {
                await _mainRepository.UpdateIsOnlineByUserId(true, SystemConstants.loggedInUser.Id);
                BtnOnlineState.Text = "مشغول";
                BtnOnlineState.BackColor = Color.FromArgb(0, 122, 204);
            }

        }
        private void DtgUsers_SelectionChanged(object sender, EventArgs e)
        {
            DtgUsers.ClearSelection();
        }
    }
}
