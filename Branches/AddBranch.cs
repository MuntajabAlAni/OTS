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

namespace OTS.Ticketing.Win.Branches
{
    public partial class AddBranch : Form
    {
        readonly BranchRepository branchRepository = new BranchRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly long _id;

        public AddBranch(long id)
        {
            _id = id;
            InitializeComponent();
        }

        private async void AddBranch_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id != 0)
                {
                    BranchInfo branchInfo = await branchRepository.GetBranchById(_id);
                    TxtName.Text = branchInfo.Name;
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
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_id == 0)
                {
                    await branchRepository.AddBranch(TxtName.Text);
                }
                else
                {
                    await branchRepository.UpdateBranch(_id, TxtName.Text);
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

        private void AddBranch_KeyDown(object sender, KeyEventArgs e)
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
