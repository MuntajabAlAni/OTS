using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Users
{
    public partial class AddUser : Form
    {
        private readonly UserRepository UserRepository = new UserRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly long _id;
        public AddUser(long id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void AddUser_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id != 0)
                {
                    UserInfo UserInfo = await UserRepository.GetUserById(_id);
                    if (UserInfo.UserName == "admin")
                    {
                        TxtUserName.Enabled = false;
                        CbState.Enabled = false;
                    }
                    TxtDisplayName.Text = UserInfo.DisplayName;
                    TxtUserName.Text = UserInfo.UserName;
                    TxtPassword.Text = UserInfo.Password;
                    TxtIp.Text = UserInfo.Ip;
                    TxtRemarks.Text = UserInfo.Remarks;
                    CbState.Checked = UserInfo.State;
                    BtnAdd.Text = "تعديل";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    await UserRepository.AddUser(TxtDisplayName.Text, TxtUserName.Text, TxtPassword.Text,
                        CbState.Checked, TxtIp.Text, TxtRemarks.Text);
                }
                else
                {
                    await UserRepository.UpdateUser(_id, TxtDisplayName.Text, TxtUserName.Text, TxtPassword.Text,
                        CbState.Checked, TxtIp.Text, TxtRemarks.Text);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
    }
}
