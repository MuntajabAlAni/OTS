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

namespace OTS.Ticketing.Win.Users
{
    public partial class DisplayUsers : Form
    {
        readonly UserRepository userRepository = new UserRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public DisplayUsers()
        {
            InitializeComponent();
        }

        private void DisplayUsers_Load(object sender, EventArgs e)
        {
            try
            {
                if (SystemConstants.userRoles.Contains(((long)RoleType.AddUser)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAdd.Visible = true;
                GetDtgUsersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void GetDtgUsersData()
        {
            try
            {
                DtgUsers.DataSource = SystemConstants.ToDataTable(await userRepository.GetAllUsers());
                DtgUsers.Columns["Id"].HeaderText = "ت";
                DtgUsers.Columns["displayName"].HeaderText = "اسم الموظف";
                DtgUsers.Columns["userName"].Visible = false;
                DtgUsers.Columns["passwordHash"].Visible = false;
                DtgUsers.Columns["state"].Visible = false;
                DtgUsers.Columns["ip"].Visible = false;
                DtgUsers.Columns["remarks"].Visible = false;
                DtgUsers.Columns["salt"].Visible = false;
                DtgUsers.Columns["IsDeleted"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void DtgUsers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.EditUser)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    return;
                long id = Convert.ToInt64(DtgUsers.SelectedRows[0].Cells["Id"].Value.ToString());
                AddUser addUser = new AddUser(id);
                addUser.ShowDialog();
                GetDtgUsersData();
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

        private void DisplayUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(0);
            addUser.ShowDialog();
            GetDtgUsersData();
        }
    }
}
