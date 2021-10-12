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
        private readonly BranchRepository branchRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private BranchInfo _branchInfo;

        private readonly long _id;

        public AddBranch(long id)
        {
            branchRepository = new BranchRepository();
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
                    _branchInfo = await branchRepository.GetBranchById(_id);
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
                if (_id == 0)
                {

                    BranchInfo branchInfo = GetFormData();
                    long addedId = await branchRepository.AddBranch(branchInfo);
                    await _activityLogRepository.AddActivityLog(
                        new ActivityLogInfo(ActivityType.AddBranch, addedId, "إضافة فرع"));
                }
                else
                {
                    await branchRepository.UpdateBranch(_branchInfo);
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
                Name = TxtName.Text
            };
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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
