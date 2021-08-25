using NLog;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.MainForms;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Softwares;
using OTS.Ticketing.Win.States;
using OTS.Ticketing.Win.Tickets;
using OTS.Ticketing.Win.Users;
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
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
                Logger.Error(ex);
            }

        }
        private void ImbClose_Click(object sender, EventArgs e)
        {
            Exit();
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
            this.Close();
            SystemConstants.Initialize();
            Login login = new Login();
            login.Show();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }
        private async void Main_Load(object sender, EventArgs e)
        {
            try
            {
                BtnHome.PerformClick();
                var UserInfo = await ticketRepository.GetUserById(SystemConstants.loggedInUserId);
                if (UserInfo.UserName == "admin")
                {
                    BtnAddTicket.Visible = true;
                    BtnCompanies.Visible = true;
                    BtnUsers.Visible = true;
                    BtnPhoneNumbres.Visible = true;
                    BtnSoftwares.Visible = true;
                    BtnStates.Visible = true;
                    BtnOldTickets.Visible = true;
                    return;
                }
                if (UserInfo.UserName == "Noor")
                {
                    BtnTickets.Visible = false;
                    BtnAddTicket.Visible = true;
                    BtnAddTicket.Location = new Point(0, 162);
                    return;
                }
                BtnTickets.Location = new Point(0, 162);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void BtnTickets_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("DisplayTickets")) return;
            ApplingFormOnContainer(new DisplayTickets());
        }
        private async void BtnAddTicket_Click(object sender, EventArgs e)
        {
            var UserInfo = await ticketRepository.GetUserById(SystemConstants.loggedInUserId);
            if (UserInfo.UserName != "admin" & UserInfo.UserName != "Noor")
            {
                return;
            }
            ApplingFormOnContainer(new AddTicket());
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Exit();
            }
        }

        private void BtnCompanies_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("DisplayCompanies")) return;
            ApplingFormOnContainer(new DisplayCompanies(false));
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("DisplayUsers")) return;
            ApplingFormOnContainer(new DisplayUsers());
        }

        private void BtnPhoneNumbres_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("DisplayPhoneNumbers")) return;
            ApplingFormOnContainer(new DisplayPhoneNumbers(false));
        }

        private void Exit()
        {
            DialogResult dr;
            dr = MessageBox.Show("هل انت متأكد من إغلاق البرنامج ؟", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnStates_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("DisplayStates")) return;
            ApplingFormOnContainer(new DisplayStates());
        }

        private void BtnSoftwares_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("DisplaySoftwares")) return;
            ApplingFormOnContainer(new DisplaySoftwares());
        }

        private void BtnOldTickets_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("DisplayOldTickets")) return;
            ApplingFormOnContainer(new DisplayOldTickets());
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Online Technical Support 6059\n1.0.0.2\nFuture of Technology Co.\n2021 ", "عن", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser displayUser = new AddUser(SystemConstants.loggedInUserId);
            displayUser.ShowDialog();
        }
    }
}
