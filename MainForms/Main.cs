﻿using OTS.Ticketing.Software.MainForms;
using OTS.Ticketing.Software.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Software
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            FileToolStripMenuItem.DropDownDirection = ToolStripDropDownDirection.BelowLeft;
            HelpToolStripMenuItem.DropDownDirection = ToolStripDropDownDirection.BelowLeft;
        }

        private void ApplingFormOnContainer(object obj)
        {
            if (PnlContainer.Controls.Count > 0) PnlContainer.Controls.RemoveAt(0);
            Form addForm = obj as Form;
            addForm.TopLevel = false;
            addForm.Dock = DockStyle.Fill;
            PnlContainer.Controls.Add(addForm);
            PnlContainer.Tag = addForm;
            addForm.Show();
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

        private void Main_Load(object sender, EventArgs e)
        {
         BtnHome_Click(sender, e);
        }

        private void BtnTickets_Click(object sender, EventArgs e)
        {
            if (PnlContainer.Controls.ContainsKey("DisplayTickets")) return;
            ApplingFormOnContainer(new DisplayTickets());
        }

        
    }
}