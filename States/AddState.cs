using NLog;
using OTS.Ticketing.Win.ActivityLog;
using OTS.Ticketing.Win.Enums;
using System;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.States
{
    public partial class AddState : Form
    {
        readonly StateRepository _stateRepository;
        readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly long _id;
        public AddState(long id)
        {
            _stateRepository = new StateRepository();
            _activityLogRepository = new ActivityLogRepository();
            InitializeComponent();
            _id = id;
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtName.Text == "")
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StateInfo state = GetFormData();
                if (_id == 0)
                {
                    long addedId = await _stateRepository.AddState(state);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.AddState,
                        addedId, "إضافة حالة"));
                }
                else
                {
                    await _stateRepository.UpdateState(state);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.EditState,
                         _id, "تعديل حالة"));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private StateInfo GetFormData()
        {
            return new StateInfo
            {
                Id = _id,
                Name = TxtName.Text
            };
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddState_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id != 0)
                {
                    StateInfo stateInfo = await _stateRepository.GetStateById(_id);
                    TxtName.Text = stateInfo.Name;
                    BtnAdd.Text = "تعديل";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private void AddState_KeyDown(object sender, KeyEventArgs e)
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
