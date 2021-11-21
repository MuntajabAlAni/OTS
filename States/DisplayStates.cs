using NLog;
using OTS.Ticketing.Win.Enums;
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
                if (!SystemConstants.userRoles.Contains(((long)RoleType.AddState)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAdd.Visible = false;
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
            DataTable dt = SystemConstants.ToDataTable(await stateRepository.GetAll());
            DataColumn dc = new DataColumn("ت", typeof(int));
            dt.Columns.Add(dc);
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dr["ت"] = i + 1;
                i++;
            }
            DtgStates.DataSource = dt;
            DtgStates.Columns["ت"].DisplayIndex = 0;
            DtgStates.Columns["Id"].Visible = false;
            DtgStates.Columns["Name"].HeaderText = "الحالة";
            DtgStates.Columns["IsDeleted"].Visible = false;

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

        private void DtgStates_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.EditState)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    return;
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
    }
}
