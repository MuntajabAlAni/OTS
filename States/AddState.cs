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
                }
                else
                {
                    await stateRepository.UpdateState(_id, TxtName.Text);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnAdd_Click");
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
                SystemConstants.ErrorLog(ex, "AddState_Load");
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
