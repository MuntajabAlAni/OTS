using Ionic.Zip;
using NLog;
using OTS.Ticketing.Win.ActivityLog;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.MainForms;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Tasks;
using OTS.Ticketing.Win.Softwares;
using OTS.Ticketing.Win.States;
using OTS.Ticketing.Win.Tickets;
using OTS.Ticketing.Win.Users;
using OTS.Ticketing.Win.Utils;
using System;
using OTS.Ticketing.Win.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OTS.Ticketing.Win.UsersRoles;

namespace OTS.Ticketing.Win
{
    public partial class Main : Form
    {
        private readonly MainRepository _mainRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly CancellationTokenSource _cancellationTokenSource;
        public Main()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _mainRepository = new MainRepository();
            _activityLogRepository = new ActivityLogRepository();
            InitializeComponent();
            UpdateSession();
            UpdateOffline();
            FileToolStripMenuItem.DropDownDirection = ToolStripDropDownDirection.BelowLeft;
            HelpToolStripMenuItem.DropDownDirection = ToolStripDropDownDirection.BelowLeft;
            PnlLoad.Dock = DockStyle.Fill;
            PnlLoad.BringToFront();
            PnlLoad.Visible = false;
        }
        private async void Main_Load(object sender, EventArgs e)
        {
            try
            {
                SessionInfo session = new SessionInfo
                {
                    IsOnline = true,
                    UserId = SystemConstants.loggedInUser.Id
                };

                await _mainRepository.UpdateIsOnlineByUserId(session);

                BtnHome.PerformClick();
                if (SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                {
                    BtnAddTicket.Visible = true;
                    BtnCompanies.Visible = true;
                    BtnUsers.Visible = true;
                    BtnPhoneNumbres.Visible = true;
                    BtnSoftwares.Visible = true;
                    BtnStates.Visible = true;
                    BtnOldTickets.Visible = true;
                    BtnActivityLog.Visible = true;
                    BtnScheduling.Visible = true;
                    BtnDisplayEmployees.Visible = true;
                    return;
                }
                if (SystemConstants.userRoles.Contains(((long)RoleType.CallReceiver)))
                {
                    BtnTickets.Visible = false;
                    BtnAddTicket.Visible = true;
                    BtnAddTicket.Location = new Point(0, 162);
                    return;
                }
                if (SystemConstants.userRoles.Contains(((long)RoleType.OTSManager)))
                {
                    BtnOldTickets.Visible = true;
                    BtnActivityLog.Visible = true;
                    BtnScheduling.Visible = true;
                    BtnDisplayEmployees.Visible = true;
                }
                BtnTickets.Location = new Point(0, 162);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void ApplingFormOnContainer(object obj)
        {
            try
            {
                if (PnlContainer.Controls.Count > 0) PnlContainer.Controls.RemoveAt(0);
                Form addForm = obj as Form;
                addForm.TopLevel = false;
                addForm.Dock = DockStyle.Fill;
                PnlContainer.Controls.Add(addForm);
                PnlContainer.Tag = addForm;
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void ImbClose_Click(object sender, EventArgs e)
        {
            Exit();
        }
        private void ImbMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ImbMaximize.Visible = false;
            ImbNormalSize.Visible = true;
            bunifuFormDock1.AllowFormDragging = false;
        }
        private void ImbNormalSize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            ImbMaximize.Visible = true;
            ImbNormalSize.Visible = false;
        }
        private void ImbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void BtnHome_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.Home;
                if (PnlContainer.Controls.ContainsKey("Home")) return;
                ApplingFormOnContainer(new Home());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void LOGO_Click(object sender, EventArgs e)
        {
            if (PnlMenuVertical.Width == 250) PnlMenuVertical.Width = 100;
            else PnlMenuVertical.Width = 250;
        }
        private async void ChangeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.SignOut,
                     SystemConstants.loggedInUser.Id, "تسجيل خروج مستخدم"));

                SystemConstants.currentEvent = EventType.LoggedOut;

                SessionInfo session = new SessionInfo
                {
                    UserId = SystemConstants.loggedInUser.Id,
                    LastEvent = (int)EventType.LoggedOut,
                    ComputerName = Environment.MachineName,
                    SessionId = SystemConstants.loggedInUserSessionId,
                    Number = "",
                    IsOnline = false
                };

                await _mainRepository.UpdateIsOnlineByUserId(session);
                await _mainRepository.UpdateSession(session);

                this.Close();
                Login login = new Login();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }
        private void BtnTickets_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.DisplayTickets;
                if (PnlContainer.Controls.ContainsKey("DisplayTickets")) return;
                ApplingFormOnContainer(new DisplayTickets());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnAddTicket_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.AddTicket;
                ApplingFormOnContainer(new AddTicket());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape | (e.KeyCode == Keys.F4 & ModifierKeys == Keys.Alt))
            {
                Exit();
            }
        }
        private void BtnCompanies_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.Companies;
                if (PnlContainer.Controls.ContainsKey("DisplayCompanies")) return;
                ApplingFormOnContainer(new DisplayCompanies(false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnUsers_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.Users;
                if (PnlContainer.Controls.ContainsKey("DisplayUsers")) return;
                ApplingFormOnContainer(new DisplayUsers());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnPhoneNumbres_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.PhoneNumbers;
                if (PnlContainer.Controls.ContainsKey("DisplayPhoneNumbers")) return;
                ApplingFormOnContainer(new DisplayPhoneNumbers(false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void Exit()
        {
            try
            {
                DialogResult dr;
                dr = MessageBox.Show(LocalizationMessages.GetMessage("ExitConfirmation"), "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.SignOut,
                                         SystemConstants.loggedInUser.Id, "تسجيل خروج مستخدم"));

                    SessionInfo session = new SessionInfo
                    {
                        UserId = SystemConstants.loggedInUser.Id,
                        LastEvent = (int)EventType.LoggedOut,
                        ComputerName = Environment.MachineName,
                        SessionId = SystemConstants.loggedInUserSessionId,
                        Number = "",
                        IsOnline = false
                    };

                    await _mainRepository.UpdateIsOnlineByUserId(session);
                    await _mainRepository.UpdateSession(session);

                    Application.Exit();
                    Environment.Exit(Environment.ExitCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnStates_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.States;
                if (PnlContainer.Controls.ContainsKey("DisplayStates")) return;
                ApplingFormOnContainer(new DisplayStates());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnSoftwares_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.Softwares;
                if (PnlContainer.Controls.ContainsKey("DisplaySoftwares")) return;
                ApplingFormOnContainer(new DisplaySoftwares());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnOldTickets_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.DisplayOldTickets;
                if (PnlContainer.Controls.ContainsKey("DisplayOldTickets")) return;
                ApplingFormOnContainer(new DisplayOldTickets(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Online Technical Support 6059\n{Application.ProductVersion}\nFuture of Technology Co.\n2021 ", "حول البرنامج",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser displayUser = new AddUser(SystemConstants.loggedInUser.Id);
            displayUser.ShowDialog();
        }
        private void BtnActivityLog_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.DisplayActivities;
                if (PnlContainer.Controls.ContainsKey("DisplayActivities")) return;
                ApplingFormOnContainer(new DisplayActivities());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnScheduling_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.Schedule;
                if (PnlContainer.Controls.ContainsKey("Schedule")) return;
                ApplingFormOnContainer(new DisplayTasks());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnDisplayEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.currentEvent = EventType.DisplayEmployees;
                if (PnlContainer.Controls.ContainsKey("DisplayEmployees")) return;
                ApplingFormOnContainer(new DisplayEmployees());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void BackupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PnlLoad.Visible = true;
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    RestoreDirectory = true,
                    CreatePrompt = false,
                    FileName = "OTSBackup.bak",
                    Title = "أختيار مكان حفظ الملف"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    await _mainRepository.BackupDatabase(saveFileDialog.FileName);
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.Password = "edariworkmen_fot";
                        zip.AddFile(saveFileDialog.FileName);
                        zip.Save(saveFileDialog.FileName.Replace(".bak", ".zip"));
                    }
                    File.Delete(saveFileDialog.FileName);
                    MessageBox.Show("! تم حفظ النسخة الإحتياطية");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
            finally { PnlLoad.Visible = false; }
        }
        private async void RestoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PnlLoad.Visible = true;
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "اختيار ملف النسخة الاحتياطية",
                    Filter = "ZIP Files | *.zip"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ZipFile zipFile = ZipFile.Read(openFileDialog.FileName);
                    string path = "E:\\";
                    Directory.CreateDirectory(path);
                    foreach (ZipEntry zip in zipFile)
                    {
                        zip.Password = "edariworkmen_fot";
                        zip.Extract(path, ExtractExistingFileAction.OverwriteSilently);
                    }
                    await _mainRepository.RestoreDatabase(path + "OTSBackup.bak");
                    File.Delete(path + "OTSBackup.bak");
                    MessageBox.Show("! تم إسترجاع النسخة الإحتياطية");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
            finally { PnlLoad.Visible = false; }
        }
        private void PnlLoad_VisibleChanged(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                control.Enabled = !PnlLoad.Visible;
            }
        }
        private void UpdateSession()
        {
            CancellationToken cancellationToken = _cancellationTokenSource.Token;
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var result = await _mainRepository.UpdateSession(new SessionInfo(SystemConstants.currentEvent));
                        await Task.Delay(5000);
                        if (result == 0)
                        {
                            MessageBox.Show("تم تسجيل الدخول أكثر من مرة");
                            Application.Exit();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Error(ex);
                    }
                }
            });
        }

        private void UpdateOffline()
        {
            CancellationToken cancellationToken = _cancellationTokenSource.Token;
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        await _mainRepository.UpdateOfflineUsers();
                        await Task.Delay(60000);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Error(ex);
                    }
                }
            });
        }
    }
}