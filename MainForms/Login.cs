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
using System.IO;
using OTS.Ticketing.Win.DatabaseConnection;
using NLog;
using OTS.Ticketing.Win.Users;
using System.Globalization;
using OTS.Ticketing.Win.Enums;
using OTS.Ticketing.Win.Utils;
using System.Resources;
using System.Reflection;
using OTS.Ticketing.Win.ActivityLog;
using OTS.Ticketing.Win.UsersRoles;

namespace OTS.Ticketing.Win.MainForms
{
    public partial class Login : Form
    {
        private readonly MainRepository _mainRepository;
        private readonly UserRepository _userRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        // MAKE FORM MOVEABLE
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Login()
        {
            try
            {
                _mainRepository = new MainRepository();
                _userRepository = new UserRepository();
                _activityLogRepository = new ActivityLogRepository();
                InitializeComponent();
                IniFile iniFile = new IniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini"));
                SystemConstants.Database = iniFile.IniReadValue("Connection", "Database");
                SystemConstants.ServerIp = iniFile.IniReadValue("Connection", "ServerIp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        public async Task LoginToMain()
        {
            try
            {
                BtnLogin.Enabled = false;
                UserInfo request = GetFormData();
                UserInfo result = await _userRepository.CheckUserNameAndPasswordAsync(request);

                var settings = await _mainRepository.GetSettings();
                if (settings.Version != Application.ProductVersion)
                {
                    MessageBox.Show("!! يرجى تحديث البرنامج");
                    return;
                }
                if (result == null)
                {
                    MessageBox.Show(LocalizationMessages.GetMessage("WrongInformations"));
                    return;
                }
                if (TxtUserName.Text.ToLower() != "admin" & TxtUserName.Text.ToLower() != "noor" & TxtUserName.Text.ToLower() != "batool")
                {
                    if (string.IsNullOrWhiteSpace(TxtNumber.Text))
                    {
                        MessageBox.Show("يرجى إدخال الرقم المخصص");
                        return;
                    }
                    if ((Convert.ToInt32(TxtNumber.Text) < 100 | Convert.ToInt32(TxtNumber.Text) > 125)
                        & (Convert.ToInt32(TxtNumber.Text) < 3600 | Convert.ToInt32(TxtNumber.Text) > 3625))
                    {
                        TxtNumber.Text = "";
                        MessageBox.Show("! يرجى إدخال الرقم بشكل صحيح من الارقام الموجودة");
                        return;
                    }
                }
                SystemConstants.Initialize();

                SystemConstants.loggedInUser = result;
                SystemConstants.loggedInUserSessionId = Guid.NewGuid();

                List<long> roles = new List<long>();
                var userRolesInfo = await _mainRepository.GetUserRoles(result.Id);

                foreach (RoleInfo role in userRolesInfo)
                {
                    roles.Add(role.RoleId);
                }

                SystemConstants.userRoles = roles;

                await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.SignIn,
                    SystemConstants.loggedInUser.Id, "تسجيل دخول مستخدم"));

                SessionInfo session = new SessionInfo
                {
                    IsOnline = true,
                    Number = TxtNumber.Text,
                    SessionId = SystemConstants.loggedInUserSessionId,
                    UserId = SystemConstants.loggedInUser.Id
                };

                await _mainRepository.InitializeUserSession(session);

                if (CbRememberMe.Checked)
                {
                    Properties.Settings.Default.Username = TxtUserName.Text;
                    Properties.Settings.Default.Number = TxtNumber.Text;
                    Properties.Settings.Default.Save();
                }

                Main main = new Main();
                this.Hide();
                main.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("15101998"))
                    MessageBox.Show("! يرجى تعديل تاريخ الجهاز", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
            finally
            {
                BtnLogin.Enabled = true;
            }
        }

        private UserInfo GetFormData()
        {
            return new UserInfo
            {
                UserName = TxtUserName.Text,
                PasswordHash = TxtPassword.Text
            };
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            await LoginToMain();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(TxtPassword.Text))
                {
                    TxtPassword.Focus();
                    return;
                }
                BtnLogin.PerformClick();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin.PerformClick();
            }
        }

        private void ImbLogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            DatabaseServer database = new DatabaseServer();
            database.ShowDialog();
            this.Show();
        }

        private void TxtUserName_Enter(object sender, EventArgs e)
        {
            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
            if (myCurrentLanguage.Culture.TwoLetterISOLanguageName != "en")
            {
                SendKeys.Send("%+");
            }
        }

        private void TxtUserName_Leave(object sender, EventArgs e)
        {
            TxtNumber.Visible = TxtUserName.Text.ToLower() != "admin" & TxtUserName.Text.ToLower() != "noor" & TxtUserName.Text.ToLower() != "batool";
            LblNumber.Visible = TxtUserName.Text.ToLower() != "admin" & TxtUserName.Text.ToLower() != "noor" & TxtUserName.Text.ToLower() != "batool";
        }

        private void TxtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CbRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (!CbRememberMe.Checked)
            {
                Properties.Settings.Default.Reset();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            TxtUserName.Text = Properties.Settings.Default.Username;
            TxtNumber.Text = Properties.Settings.Default.Number;

            if (!string.IsNullOrWhiteSpace(TxtUserName.Text))
            {
                CbRememberMe.Checked = true;
                TxtPassword.Select();
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
