using NLog;
using OTS.Ticketing.Win.Users;
using System;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.ActivityLog
{
    public partial class DisplayActivities : Form
    {
        private readonly ActivityLogRepository _activityLogRepository;
        private readonly UserRepository _userRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public DisplayActivities()
        {
            _activityLogRepository = new ActivityLogRepository();
            _userRepository = new UserRepository();
            InitializeComponent();
        }

        private void DisplayActivities_Load(object sender, EventArgs e)
        {
            DtpToDate.Value = DateTime.Today;
            FillUsersComboBox();
            FillActivitiesComboBox();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void FillUsersComboBox()
        {
            try
            {
                CombUser.DisplayMember = "displayName";
                CombUser.ValueMember = "Id";
                CombUser.DataSource = await _userRepository.GetAllUsers();
                CombUser.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillActivitiesComboBox()
        {
            try
            {
                CombActivities.DisplayMember = "activityName";
                CombActivities.ValueMember = "Id";

                var activities = await _activityLogRepository.GetAllActivities();
                activities.Insert(0, (new ActivityInfo { Id = 0, ActivityName = "" }));

                CombActivities.DataSource = activities;
                CombActivities.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                GetActivityLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private async void GetActivityLog()
        {
            ActivityLogReportInfo logReportInfo = GetFormData();

            DtgActivityLog.DataSource = await _activityLogRepository.GetActivityLog(logReportInfo);

            DtgActivityLog.Columns["Id"].Visible = false;
            DtgActivityLog.Columns["UserName"].HeaderText = "اسم المستخدم";
            DtgActivityLog.Columns["ActivityDate"].HeaderText = "تاريخ الحركة";
            DtgActivityLog.Columns["ActivityType"].HeaderText = "نوع الحركة";
            DtgActivityLog.Columns["computerName"].HeaderText = "اسم الحاسوب";
            DtgActivityLog.Columns["details"].HeaderText = "التفاصيل";
            DtgActivityLog.Columns["affectedId"].Visible = false;
        }

        private ActivityLogReportInfo GetFormData()
        {
            return new ActivityLogReportInfo()
            {
                UserId = Convert.ToInt64(CombUser.SelectedValue),
                ActivityId = Convert.ToInt64(CombActivities.SelectedValue),
                FromDate = DtpFromDate.Value,
                ToDate = DtpToDate.Value
            };
        }

        private void DtgActivityLog_DoubleClick(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt)
            {
                if (!(DtgActivityLog.DataSource is null))
                {
                    string affectedId = DtgActivityLog.SelectedRows[0].Cells["AffectedId"].Value.ToString();
                    MessageBox.Show("Affected ID : " + affectedId);
                }
            }
        }
    }
}
