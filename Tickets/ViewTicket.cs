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
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly TicketRepository _ticketRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private TicketsView _ticket;
        private readonly long _number;
        private readonly long _revision;
        public ViewTicket(long number, long revision)
        {
            InitializeComponent();
            _ticketRepository = new TicketRepository();
            _activityLogRepository = new ActivityLogRepository();
            _number = number;
            _revision = revision;
        }

        private async void ViewTicket_Load(object sender, EventArgs e)
        {
            _ticket = await _ticketRepository.GetDetailsByNumberAndRevision(_number, _revision);
            LblNumber.Text = _ticket.Number.ToString();
            LblRevision.Text = _ticket.Revision.ToString();
            LblCompanyName.Text = _ticket.CompanyName;
            LblPhoneNumber.Text = _ticket.PhoneNumber;
            LblSoftware.Text = _ticket.SoftwareName;
            LblUser.Text = _ticket.UserName;
            LblOpenDate.Text = _ticket.OpenDate.ToString();
            LblProblem.Text = _ticket.Problem != null ? _ticket.Problem.ToString() : "";
            LblState.Text = _ticket.State;
            LblTransferedTo.Text = _ticket.TransferedTo != null ? _ticket.TransferedTo : ""; ;
            LblRemarks.Text = _ticket.Remarks != null ? _ticket.Remarks.ToString() : "";
            ToggleClosed.Checked = _ticket.IsClosedView;
            ToggleIsIndexed.Checked = _ticket.IsIndexedView;
            ToggleRemotely.Checked = _ticket.RemotelyView;

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
