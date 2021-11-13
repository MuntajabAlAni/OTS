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
        private readonly MainRepository _mainRepository;
        private readonly TicketRepository _ticketRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private static bool isBtnChecked;

        public Home()
        {
            _mainRepository = new MainRepository();
            _ticketRepository = new TicketRepository();
            InitializeComponent();
        }
        private async void Home_Load(object sender, EventArgs e)
        {
            try
            {
                if (isBtnChecked)
                {
                    BtnOnlineState.Text = "متفرغ";
                    BtnOnlineState.BackColor = Color.Crimson;
                }
                else
                {
                    BtnOnlineState.Text = "مشغول";
                    BtnOnlineState.BackColor = Color.FromArgb(0, 122, 204);
                }
                if (SystemConstants.loggedInUser.Id != 1 & SystemConstants.loggedInUser.Id != 2)
                {
                    BtnOnlineState.Visible = true;
                }

                await GetDtgLastTicketsData();

                if (!File.Exists(Path.Combine("Notes.txt")))
                {
                    File.CreateText(Path.Combine("Notes.txt")).Close();
                }
                RtbNotes.SelectionAlignment = HorizontalAlignment.Center;
                RtbNotes.Text = File.ReadAllText(Path.Combine("Notes.txt"));
                GetDtgUsersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async Task GetDtgLastTicketsData()
        {
            try
            {
                DataTable dt = SystemConstants.ToDataTable(await _ticketRepository.GetTodaysTickets());
                DataColumn dc = new DataColumn("ت", typeof(int));
                dt.Columns.Add(dc);
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    dr["ت"] = i + 1;
                    i++;
                }
                DtgLastTickets.DataSource = dt;
                DtgLastTickets.Columns["ت"].DisplayIndex = 0;
                DtgLastTickets.Columns["Number"].HeaderText = LocalizationMessages.GetMessage("Number");
                DtgLastTickets.Columns["OpenDate"].HeaderText = LocalizationMessages.GetMessage("OpenDate");
                DtgLastTickets.Columns["CloseDate"].HeaderText = LocalizationMessages.GetMessage("CloseDate");
                DtgLastTickets.Columns["PhoneNumber"].HeaderText = LocalizationMessages.GetMessage("PhoneNumber");
                DtgLastTickets.Columns["SoftwareName"].HeaderText = LocalizationMessages.GetMessage("SoftwareName");
                DtgLastTickets.Columns["UserName"].HeaderText = LocalizationMessages.GetMessage("UserName");
                DtgLastTickets.Columns["CompanyName"].HeaderText = LocalizationMessages.GetMessage("CompanyName");
                DtgLastTickets.Columns["IsIndexedView"].HeaderText = LocalizationMessages.GetMessage("IsIndexed");
                DtgLastTickets.Columns["StateName"].HeaderText = LocalizationMessages.GetMessage("State");
                DtgLastTickets.Columns["Problem"].HeaderText = LocalizationMessages.GetMessage("Problem");
                DtgLastTickets.Columns["Revision"].HeaderText = LocalizationMessages.GetMessage("Revision");
                DtgLastTickets.Columns["IsClosedView"].HeaderText = LocalizationMessages.GetMessage("IsClosed");
                DtgLastTickets.Columns["TransferedToName"].HeaderText = LocalizationMessages.GetMessage("TransferedTo");
                DtgLastTickets.HideUntranslatedColumns();
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
                    Image online = SystemConstants.loggedInUser.Id == 4 ? Properties.Resources.Wake : Properties.Resources.Online;
                    Image ticketOnProgress = SystemConstants.loggedInUser.Id == 4 ? Properties.Resources.Wake : Properties.Resources.TicketOnProgress;
                    Image offline = SystemConstants.loggedInUser.Id == 4 ? Properties.Resources.Sleep : Properties.Resources.Offline;

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
                            if (row.Cells["اخر حركة"].Value.ToString() == "مشغول ببطاقة")
                            {
                                row.Cells["الحالة"].Value = ticketOnProgress;
                            }
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
                SessionInfo session = new SessionInfo
                {
                    IsOnline = false,
                    UserId = SystemConstants.loggedInUser.Id
                };

                await _mainRepository.UpdateIsOnlineByUserId(session);
                BtnOnlineState.Text = "متفرغ";
                BtnOnlineState.BackColor = Color.Crimson;
                isBtnChecked = true;
            }
            else if (BtnOnlineState.Text == "متفرغ")
            {
                SessionInfo session = new SessionInfo
                {
                    IsOnline = true,
                    UserId = SystemConstants.loggedInUser.Id
                };

                await _mainRepository.UpdateIsOnlineByUserId(session);
                BtnOnlineState.Text = "مشغول";
                BtnOnlineState.BackColor = Color.FromArgb(0, 122, 204);
                isBtnChecked = false;
            }

        }
        private void DtgUsers_SelectionChanged(object sender, EventArgs e)
        {
            DtgUsers.ClearSelection();
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await GetDtgLastTicketsData();
        }

        private async void DtgLastTickets_DoubleClick(object sender, EventArgs e)
        {
            if (DtgLastTickets.Rows.Count == 0) return;
            long selectedNumber = Convert.ToInt64(DtgLastTickets.SelectedRows[0].Cells["Number"].Value.ToString());
            long selectedRevision = Convert.ToInt64(DtgLastTickets.SelectedRows[0].Cells["Revision"].Value.ToString());
            TicketInfo selectedTicket = await _ticketRepository.GetDetailsByNumberAndRevision(selectedNumber, selectedRevision);
            TicketRemarks remarks = new TicketRemarks(selectedTicket);
            remarks.ShowDialog();
        }
    }
}
