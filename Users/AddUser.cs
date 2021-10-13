using NLog;
using OTS.Ticketing.Win.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OTS.Ticketing.Win.Enums;
using OTS.Ticketing.Win.ActivityLog;

namespace OTS.Ticketing.Win.Users
{
    public partial class AddUser : Form
    {
        private readonly UserRepository _userRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly long _id;
        public AddUser(long id)
        {
            _activityLogRepository = new ActivityLogRepository();
            _userRepository = new UserRepository();
            InitializeComponent();
            _id = id;
        }

        private async void AddUser_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id != 0)
                {
                    UserInfo UserInfo = await _userRepository.GetUserById(_id);
                    if (UserInfo.UserName == "admin")
                    {
                        TxtUserName.Enabled = false;
                        CbState.Enabled = false;
                    }
                    TxtDisplayName.Text = UserInfo.DisplayName;
                    TxtUserName.Text = UserInfo.UserName;
                    TxtPassword.Text = "            ";
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
                if (TxtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("الرجاء ادخال كلمة السر");
                    return;
                }

                if (TxtUserName.Text.Trim() == "")
                {
                    MessageBox.Show("الرجاء ادخال اسم المستخدم");
                    return;
                }
                UserInfo user = GetFormData();
                if (_id == 0)
                {

                    long addedId = await _userRepository.AddUser(user);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.AddUser,
                        addedId, "إضافة مستخدم"));
                }
                else
                {
                    await _userRepository.UpdateUser(user);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.EditUser,
                                            _id, "تعديل مستخدم"));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                if (ex.Message.Contains("66DCF95C0F369E53"))
                {
                    MessageBox.Show("هذا المستخدم موجود سابقاً", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private UserInfo GetFormData()
        {
            return new UserInfo
            {
                Id = _id,
                DisplayName = TxtDisplayName.Text,
                UserName = TxtUserName.Text,
                Password = TxtPassword.Text,
                State = CbState.Checked,
                Ip = TxtIp.Text,
                Remarks = TxtRemarks.Text
            };
        }
    }
}
