using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Software.MainForms
{
    public partial class Login : Form
    {
        public MainRepository mainRepository = new MainRepository();
        public Login()
        {
            InitializeComponent();
        }

        public void LoginToMain()
        {
            if (!mainRepository.CheckUserNameAndPassword(TxtUserName.Text, TxtPassword.Text))
            {
                MessageBox.Show("يرجى التأكد من معلومات الدخول !");
                return;

            }
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginToMain();
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
                LoginToMain();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginToMain();
            }
        }

    }
}
