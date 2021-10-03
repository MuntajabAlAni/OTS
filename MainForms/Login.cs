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
using OTS.Ticketing.Win.Utils;
using System.Resources;
using System.Reflection;

namespace OTS.Ticketing.Win.MainForms
{
    public partial class Login : Form
    {
        private readonly MainRepository mainRepository = new MainRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Login()
        {
            try
            {
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
                UserInfo result = await mainRepository.CheckUserNameAndPasswordAsync(TxtUserName.Text,
                    TxtPassword.Text);

                var settings = await mainRepository.GetSettings();
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
                if (TxtUserName.Text.ToLower() != "admin" & TxtUserName.Text.ToLower() != "noor")
                {
                    if (string.IsNullOrWhiteSpace(TxtNumber.Text))
                    {
                        MessageBox.Show("يرجى إدخال الرقم المخصص");
                        return;
                    }
                    if (Convert.ToInt32(TxtNumber.Text) < 112 | Convert.ToInt32(TxtNumber.Text) > 117)
                    {
                        TxtNumber.Text = "";
                        MessageBox.Show("! `يرجى إدخال الرقم بشكل صحيح من الارقام الموجودة");
                        return;
                    }
                }
                SystemConstants.Initialize();
                SystemConstants.loggedInUserId = result.Id;
                SystemConstants.loggedInUserSessionId = Guid.NewGuid();

                await ActivityLogUtility.ActivityLog(Enums.Activities.SignIn, "تسجيل دخول مستخدم", SystemConstants.loggedInUserId);
                await mainRepository.UpdateSessionInfoByUserId(TxtNumber.Text,
                    SystemConstants.loggedInUserSessionId,
                    SystemConstants.loggedInUserId, true);
                Main main = new Main();
                this.Hide();
                main.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
            finally
            {
                BtnLogin.Enabled = true;
            }
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
            TxtNumber.Visible = (TxtUserName.Text.ToLower() != "admin" & TxtUserName.Text.ToLower() != "noor");
            LblNumber.Visible = (TxtUserName.Text.ToLower() != "admin" & TxtUserName.Text.ToLower() != "noor");
        }

        private void TxtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
