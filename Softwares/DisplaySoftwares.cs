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

namespace OTS.Ticketing.Win.Softwares
{
    public partial class DisplaySoftwares : Form
    {
        readonly SoftwareRepository softwareRepository = new SoftwareRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DisplaySoftwares()
        {
            InitializeComponent();
        }

        private void DisplaySoftwares_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.AddSoftware)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAdd.Visible = false;
                GetDtgSoftwaresData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void GetDtgSoftwaresData()
        {
            DtgSoftwares.DataSource = SystemConstants.ToDataTable(await softwareRepository.GetAll());
            DtgSoftwares.Columns["Id"].HeaderText = "ت";
            DtgSoftwares.Columns["Name"].HeaderText = "البرنامج";
            DtgSoftwares.Columns["IsDeleted"].Visible = false;

        }

        private void DtgSoftwares_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.EditSoftware)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    return;
                long id = Convert.ToInt64(DtgSoftwares.SelectedRows[0].Cells["Id"].Value.ToString());
                AddSoftware addSoftware = new AddSoftware(id);
                addSoftware.ShowDialog();
                GetDtgSoftwaresData();
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

        private void DisplaySoftwares_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddSoftware addSoftware = new AddSoftware(0);
            addSoftware.ShowDialog();
            GetDtgSoftwaresData();
        }
    }
}
