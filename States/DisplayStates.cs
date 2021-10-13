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

namespace OTS.Ticketing.Win.States
{
    public partial class DisplayStates : Form
    {
        readonly StateRepository stateRepository = new StateRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public DisplayStates()
        {
            InitializeComponent();
        }

        private void DisplayStates_Load(object sender, EventArgs e)
        {
            try
            {
                GetDtgStatesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private async void GetDtgStatesData()
        {
            DtgStates.DataSource = SystemConstants.ToDataTable(await stateRepository.GetAllStates());
            DtgStates.Columns["Id"].HeaderText = "ت";
            DtgStates.Columns["Name"].HeaderText = "الحالة";
            DtgStates.Columns["IsDeleted"].Visible = false;

        }

        private void DtgStates_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                long id = Convert.ToInt64(DtgStates.SelectedRows[0].Cells["Id"].Value.ToString());
                AddState addState = new AddState(id);
                addState.ShowDialog();
                GetDtgStatesData();
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

        private void DisplayStates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddState addState = new AddState(0);
            addState.ShowDialog();
            GetDtgStatesData();
        }
    }
}
