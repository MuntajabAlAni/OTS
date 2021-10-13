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

namespace OTS.Ticketing.Win
{
    public partial class Main : Form
    {
        private readonly TicketRepository _ticketRepository;
        private readonly MainRepository _mainRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static int eventType;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public Main()
        {
            eventType = ((int)EventType.Home);
            _mainRepository = new MainRepository();
            _ticketRepository = new TicketRepository();
            _activityLogRepository = new ActivityLogRepository();
            InitializeComponent();
            UpdateSession();
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
                BtnHome.PerformClick();
                var UserInfo = await _ticketRepository.GetUserById(SystemConstants.loggedInUser.Id);
                if (SystemConstants.loggedInUser.Id == 1 |
                    UserInfo.UserName == "Mohammed" |
                    UserInfo.UserName == "Muntajab")
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
                if (UserInfo.UserName.ToLower() == "noor")
                {
                    BtnTickets.Visible = false;
                    BtnAddTicket.Visible = true;
                    BtnAddTicket.Location = new Point(0, 162);
                    return;
                }
                if (UserInfo.UserName.ToLower() == "ali")
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
        private async void BtnHome_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.Home);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
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
                eventType = ((int)EventType.LoggedOut);
                await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.SignOut,
                     SystemConstants.loggedInUser.Id, "تسجيل خروج مستخدم"));
                await _mainRepository.UpdateSessionInfoByUserId("",
                SystemConstants.loggedInUserSessionId,
                SystemConstants.loggedInUser.Id, false);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                Environment.MachineName, SystemConstants.loggedInUserSessionId);
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
        private async void BtnTickets_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.DisplayTickets);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                if (PnlContainer.Controls.ContainsKey("DisplayTickets")) return;
                ApplingFormOnContainer(new DisplayTickets());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void BtnAddTicket_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.AddTicket);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                var UserInfo = await _ticketRepository.GetUserById(SystemConstants.loggedInUser.Id);
                if (UserInfo.UserName != "admin" & UserInfo.UserName != "Noor")
                {
                    return;
                }
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
            if (e.KeyCode == Keys.Escape)
            {
                Exit();
            }
        }
        private async void BtnCompanies_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.Companies);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                if (PnlContainer.Controls.ContainsKey("DisplayCompanies")) return;
                ApplingFormOnContainer(new DisplayCompanies(false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void BtnUsers_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.Users);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                if (PnlContainer.Controls.ContainsKey("DisplayUsers")) return;
                ApplingFormOnContainer(new DisplayUsers());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void BtnPhoneNumbres_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.PhoneNumbers);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
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
                    eventType = ((int)EventType.LoggedOut);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.SignOut,
                                         SystemConstants.loggedInUser.Id, "تسجيل خروج مستخدم")); await _mainRepository.UpdateSessionInfoByUserId("",
                    SystemConstants.loggedInUserSessionId,
                    SystemConstants.loggedInUser.Id, false);
                    await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void BtnStates_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.States);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                if (PnlContainer.Controls.ContainsKey("DisplayStates")) return;
                ApplingFormOnContainer(new DisplayStates());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void BtnSoftwares_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.Softwares);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                if (PnlContainer.Controls.ContainsKey("DisplaySoftwares")) return;
                ApplingFormOnContainer(new DisplaySoftwares());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void BtnOldTickets_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.DisplayOldTickets);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                if (PnlContainer.Controls.ContainsKey("DisplayOldTickets")) return;
                ApplingFormOnContainer(new DisplayOldTickets());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Online Technical Support 6059\n1.0.0.4\nFuture of Technology Co.\n2021 ", "عن", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser displayUser = new AddUser(SystemConstants.loggedInUser.Id);
            displayUser.ShowDialog();
        }
        private async void BtnActivityLog_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.DisplayActivities);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                if (PnlContainer.Controls.ContainsKey("DisplayActivities")) return;
                ApplingFormOnContainer(new DisplayActivities());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void BtnScheduling_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.Schedule);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
                if (PnlContainer.Controls.ContainsKey("Schedule")) return;
                ApplingFormOnContainer(new DisplayTasks());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void BtnDisplayEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                eventType = ((int)EventType.DisplayEmployees);
                await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                    Environment.MachineName, SystemConstants.loggedInUserSessionId);
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
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var result = await _mainRepository.UpdateSessionByUserId(SystemConstants.loggedInUser.Id, eventType,
                            Environment.MachineName, SystemConstants.loggedInUserSessionId);
                        await Task.Delay(3000);
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
    }
}