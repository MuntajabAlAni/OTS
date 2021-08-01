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

        private void ImbSlide_Click(object sender, EventArgs e)
        {
            if (PnlMenuVertical.Width == 250) PnlMenuVertical.Width = 100;
            else PnlMenuVertical.Width = 250;
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

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
