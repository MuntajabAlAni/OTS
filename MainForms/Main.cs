using OTS.Ticketing.Win.MainForms;
using OTS.Ticketing.Win.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win
{
    public partial class Main : Form
    {
        readonly TicketRepository ticketRepository = new TicketRepository();
        public Main()
        {
            InitializeComponent();
            FileToolStripMenuItem.DropDownDirection = ToolStripDropDownDirection.BelowLeft;
            HelpToolStripMenuItem.DropDownDirection = ToolStripDropDownDirection.BelowLeft;
        }
        private void ApplingFormOnContainer(object obj)
        {
            try
            {
                if (PnlContainer.Controls.Count > 0) PnlContainer.Controls.RemoveAt(0);
                Form addForm = obj as Form;
                addForm.TopLevel = false;
                addForm.Dock = DockStyle.Fill;
                PnlContainer.Controls.Add(addForm);
                PnlContainer.Tag = addForm;
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "ApplingFormOnContainer");
            }

        }
        private void ImbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ImbMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ImbMaximize.Visible = false;
            ImbNormalSize.Visible = true;
            bunifuFormDock1.AllowFormDragging = false;
        }
        private void ImbNormalSize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            ImbMaximize.Visible = true;
            ImbNormalSize.Visible = false;
        }
        private void ImbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void BtnHome_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("Home")) return;
            ApplingFormOnContainer(new Home());
        }
        private void LOGO_Click(object sender, EventArgs e)
        {
            if (PnlMenuVertical.Width == 250) PnlMenuVertical.Width = 100;
            else PnlMenuVertical.Width = 250;
        }
        private void ChangeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async void Main_Load(object sender, EventArgs e)
        {
            try
            {
                BtnHome_Click(sender, e);
                var employeeInfo = await ticketRepository.GetEmployeeById(SystemConstants.loggedInEmployeeId);
                if (employeeInfo.UserName != "admin")
                {
                    BtnAddTicket.Visible = false;
                    BtnCompanies.Visible = false;
                    BtnEmployees.Visible = false;
                    BtnPhoneNumbres.Visible = false;
                    BtnSoftwares.Visible = false;
                    BtnStates.Visible = false;
                    BtnTickets.Location = new Point(0, 162);
                    if (employeeInfo.UserName == "Noor")
                    {
                        BtnTickets.Visible = false;
                        BtnAddTicket.Visible = true;
                        BtnAddTicket.Location = new Point(0, 162);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "Main_Load");
            }

        }
        private void BtnTickets_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("DisplayTickets")) return;
            ApplingFormOnContainer(new DisplayTickets());
        }
        private void BtnAddTicket_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("AddTicket")) return;
            ApplingFormOnContainer(new AddTicket());

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
