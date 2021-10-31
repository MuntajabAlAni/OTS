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
using OTS.Ticketing.Win.UsersRoles;
using System.Text.RegularExpressions;

namespace OTS.Ticketing.Win.Users
{
    public partial class AddUser : Form
    {
        private readonly UserRepository _userRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private UserInfo _userInfo;
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
                if (SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                {
                    BtnRoles.Visible = true;
                    LblRemarks.Visible = true;
                    TxtRemarks.Visible = true;
                }
                if (_id != 0)
                {
                    _userInfo = await _userRepository.GetById(_id);
                    if (_userInfo.UserName == "admin")
                    {
                        TxtUserName.Enabled = false;
                        CbState.Enabled = false;
                        BtnRoles.Enabled = false;
                    }
                    TxtDisplayName.Text = _userInfo.DisplayName;
                    TxtUserName.Text = _userInfo.UserName;
                    TxtPassword.Text = "            ";
                    TxtIp.Text = _userInfo.Ip;
                    TxtRemarks.Text = _userInfo.Remarks;
                    CbState.Checked = _userInfo.State;
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

                    long addedId = await _userRepository.Add(user);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.AddUser,
                        addedId, "إضافة مستخدم"));
                }
                else
                {
                    await _userRepository.Update(user);
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
                DisplayName = TxtDisplayName.Text.Trim(),
                UserName = TxtUserName.Text.Trim(),
                PasswordHash = TxtPassword.Text,
                State = CbState.Checked,
                Ip = TxtIp.Text,
                Remarks = TxtRemarks.Text
            };
        }

        private async void AddUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (_id != 0 & (SystemConstants.userRoles.Contains(((long)RoleType.Admin)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.DeleteUser))))
                {
                    if (MessageBox.Show("هل انت متأكد من الحذف ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.Yes)
                    {
                        await _userRepository.Delete(_userInfo);
                        await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.DeleteUser,
                                            _id, "حذف مستخدم"));
                        this.Close();
                    }
                }
            }
        }

        private void BtnRoles_Click(object sender, EventArgs e)
        {
            DisplayRoles displayRoles = new DisplayRoles(_id);
            displayRoles.ShowDialog();
        }

        private void TxtDisplayName_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-z A-Z]+[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-z A-Z-_]*$");
            if (!regex.IsMatch(TxtDisplayName.Text)) TxtDisplayName.Text = "";
        }
    }
}
