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

namespace OTS.Ticketing.Win.MainForms
{
    public partial class Login : Form
    {
        readonly MainRepository mainRepository = new MainRepository();

        public Login()
        {
            InitializeComponent();
            IniFile iniFile = new IniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"config.ini"));
            SystemConstants.Database = iniFile.IniReadValue("Connection","Database");
            SystemConstants.ServerIp = iniFile.IniReadValue("Connection","ServerIp");

        }

        public async Task LoginToMain()
        {
            try
            {
                BtnLogin.Enabled = false;
                var result = await mainRepository.CheckUserNameAndPasswordAsync(TxtUserName.Text, TxtPassword.Text);
                if (result == null)
                {
                    MessageBox.Show("يرجى التأكد من معلومات الدخول !");
                    return;
                }
                SystemConstants.loggedInEmployeeId = result.Id;
                Main main = new Main();
                this.DialogResult = DialogResult.OK;
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "LoginToMain");
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
            DatabaseServer database = new DatabaseServer();
            database.ShowDialog();
        }
    }
}
