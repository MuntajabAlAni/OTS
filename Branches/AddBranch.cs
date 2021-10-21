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
using OTS.Ticketing.Win.Enums;
using System.Windows.Forms;
using OTS.Ticketing.Win.ActivityLog;

namespace OTS.Ticketing.Win.Branches
{
    public partial class AddBranch : Form
    {
        private readonly BranchRepository _branchRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private BranchInfo _branchInfo;

        private readonly long _id;

        public AddBranch(long id)
        {
            _branchRepository = new BranchRepository();
            _activityLogRepository = new ActivityLogRepository();
            _id = id;
            InitializeComponent();
        }

        private async void AddBranch_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id != 0)
                {
                    _branchInfo = await _branchRepository.GetById(_id);
                    TxtName.Text = _branchInfo.Name;
                    BtnAdd.Text = "تعديل";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtName.Text == "")
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BranchInfo branchInfo = GetFormData();
                if (_id == 0)
                {

                    long addedId = await _branchRepository.Add(branchInfo);
                    await _activityLogRepository.AddActivityLog(
                        new ActivityLogInfo(ActivityType.AddBranch, addedId, "إضافة فرع"));
                }
                else
                {
                    await _branchRepository.Update(branchInfo);
                    await _activityLogRepository.AddActivityLog(
                        new ActivityLogInfo(ActivityType.EditBranch, _id, "تعديل فرع"));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private BranchInfo GetFormData()
        {
            return new BranchInfo
            {
                Id = _id,
                Name = TxtName.Text
            };
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (_id != 0 & (SystemConstants.userRoles.Contains(((long)RoleType.Admin)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.DeleteBranch))))
                {
                    if (MessageBox.Show("هل انت متأكد من الحذف ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.Yes)
                    {
                        await _branchRepository.Delete(_branchInfo);
                        await _activityLogRepository.AddActivityLog(
                        new ActivityLogInfo(ActivityType.DeleteBranch, _id, "حذف فرع"));
                        this.Close();
                    }
                }
            }
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAdd_Click(sender, e);
            }
        }
    }
}
