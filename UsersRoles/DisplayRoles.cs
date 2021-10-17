using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.UsersRoles
{
    public partial class DisplayRoles : Form
    {
        private readonly RoleRepository _roleRepository;
        private readonly long _userId;
        public DisplayRoles(long userId)
        {
            _userId = userId;
            _roleRepository = new RoleRepository();
            InitializeComponent();
        }

        private async void DisplayRoles_Load(object sender, EventArgs e)
        {
            List<RoleInfo> roles = await _roleRepository.Get(_userId);

            foreach (RoleInfo role in roles)
            {
                foreach (Control control in this.PnlContainer.Controls)
                {
                    if (control.GetType() == typeof(CheckBox) &&
                        control.Tag.ToString() == role.RoleId.ToString())
                        (control as CheckBox).Checked = true;
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            List<RoleInfo> roles = new List<RoleInfo>();
            foreach (Control control in this.PnlContainer.Controls)
            {
                if (control.GetType() == typeof(CheckBox) &&
                           (control as CheckBox).Checked)
                    roles.Add(new RoleInfo { RoleId = Convert.ToInt64(control.Tag) });
            }
            await _roleRepository.Update(_userId, roles);
            this.Close();
        }

        private void DisplayRoles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract | e.KeyCode == Keys.OemMinus)
                foreach (Control control in this.PnlContainer.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                        (control as CheckBox).Checked = false;
                }

            else if (e.KeyCode == Keys.Add | e.KeyCode == Keys.Oemplus)
            {
                foreach (Control control in this.PnlContainer.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                        (control as CheckBox).Checked = false;
                }
                CbAdmin.Checked = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }
    }
}
