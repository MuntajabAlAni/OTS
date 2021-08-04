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

namespace OTS.Ticketing.Win.MainForms
{
    public partial class Login : Form
    {
        public MainRepository mainRepository = new MainRepository();
        public Login()
        {
            InitializeComponent();
        }

        public async Task LoginToMain()
        {
            var result = await mainRepository.CheckUserNameAndPasswordAsync(TxtUserName.Text, TxtPassword.Text);
            if (!result)
            {
                MessageBox.Show("يرجى التأكد من معلومات الدخول !");
                return;

            }
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
            this.Close();
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

        private async void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(TxtPassword.Text))
                {
                    TxtPassword.Focus();
                    return;
                }
                await LoginToMain();
            }
        }

        private async void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await LoginToMain();
            }
        }

    }
}
