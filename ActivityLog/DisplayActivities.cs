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

namespace OTS.Ticketing.Win.ActivityLog
{
    public partial class DisplayActivities : Form
    {
        private readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public DisplayActivities()
        {
            _activityLogRepository = new ActivityLogRepository();
            InitializeComponent();
        }

        private void DisplayActivities_Load(object sender, EventArgs e)
        {
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
                CombUser.DataSource = await _activityLogRepository.GetAllUsers();
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
                CombActivities.DataSource = await _activityLogRepository.GetAllActivities();
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
            DtgActivityLog.DataSource = await _activityLogRepository.GetActivityLog(Convert.ToInt64(CombUser.SelectedValue),
                Convert.ToInt64(CombActivities.SelectedValue),
                DtpFromDate.Value,
                DtpToDate.Value);

            DtgActivityLog.Columns["Id"].Visible = false;
            DtgActivityLog.Columns["UserName"].HeaderText = "اسم المستخدم";
            DtgActivityLog.Columns["ActivityDate"].HeaderText = "تاريخ الحركة";
            DtgActivityLog.Columns["ActivityType"].HeaderText = "نوع الحركة";
            DtgActivityLog.Columns["computerName"].HeaderText = "اسم الحاسوب";
            DtgActivityLog.Columns["details"].HeaderText = "التفاصيل";
            DtgActivityLog.Columns["affectedId"].Visible = false;
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
