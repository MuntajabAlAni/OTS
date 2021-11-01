using NLog;
using OTS.Ticketing.Win.ActivityLog;
using OTS.Ticketing.Win.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class ViewTicket : Form
    {
        private readonly TicketRepository _ticketRepository;
        private TicketInfo _ticket;
        private readonly long _number;
        private readonly long _revision;
        public ViewTicket(long number, long revision)
        {
            InitializeComponent();
            _ticketRepository = new TicketRepository();
            _number = number;
            _revision = revision;
        }

        private async void ViewTicket_Load(object sender, EventArgs e)
        {
            _ticket = await _ticketRepository.GetViewByNumberAndRevision(_number, _revision);
            LblNumber.Text = _ticket.Number.ToString();
            LblRevision.Text = _ticket.Revision.ToString();
            LblCompanyName.Text = _ticket.CompanyName;
            LblPhoneNumber.Text = _ticket.PhoneNumber;
            LblSoftware.Text = _ticket.SoftwareName;
            LblUser.Text = _ticket.UserName;
            LblOpenDate.Text = _ticket.OpenDate.ToString();
            LblProblem.Text = _ticket.Problem ?? "";
            LblState.Text = _ticket.StateName;
            LblTransferedTo.Text = _ticket.TransferedToName ?? ""; ;
            LblRemarks.Text = _ticket.Remarks ?? "";
            ToggleClosed.Checked = _ticket.IsClosed;
            ToggleIsIndexed.Checked = _ticket.IsIndexed;
            ToggleRemotely.Checked = _ticket.Remotely;

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
