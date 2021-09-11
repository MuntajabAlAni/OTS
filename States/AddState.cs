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

namespace OTS.Ticketing.Win.States
{
    public partial class AddState : Form
    {
        readonly StateRepository stateRepository = new StateRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly long _id;
        public AddState(long id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    await stateRepository.AddState(TxtName.Text);
                    await ActivityLogUtility.ActivityLog(Enums.Activities.AddState, "إضافة حالة",
                        await stateRepository.GetLastAddedStateId());
                }
                else
                {
                    await stateRepository.UpdateState(_id, TxtName.Text);
                    await ActivityLogUtility.ActivityLog(Enums.Activities.EditState, "تعديل حالة", _id);
                }
                this.Close();
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

        private async void AddState_Load(object sender, EventArgs e)
        {
            try
            {
                if (TxtName.Text == "")
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_id != 0)
                {
                    StateInfo stateInfo = await stateRepository.GetStateById(_id);
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
                Application.Exit();
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
