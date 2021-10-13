﻿using System;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class TicketRemarks : Form
    {
        private readonly TicketsView _ticket;
        public TicketRemarks(TicketsView ticket)
        {
            _ticket = ticket;
            InitializeComponent();
        }

        private void TicketRemarks_Load(object sender, EventArgs e)
        {
            TxtRemrks.Text = _ticket.Remarks;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TicketRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
