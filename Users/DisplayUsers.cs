﻿using NLog;
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
                DataTable dt = SystemConstants.ToDataTable(await userRepository.GetAll());
                DataColumn dc = new DataColumn("ت", typeof(int));
                dt.Columns.Add(dc);
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    dr["ت"] = i + 1;
                    i++;
                }
                DtgUsers.DataSource = dt;
                DtgUsers.Columns["ت"].DisplayIndex = 0;
                DtgUsers.Columns["Id"].Visible = false;
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

        private void DtgUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
