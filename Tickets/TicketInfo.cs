using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Tickets
{
    public class TicketInfo
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public long PhoneNumberId { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public long SoftwareId { get; set; }
        public string SoftwareName { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string Problem { get; set; }
        public long StateId { get; set; }
        public string StateName { get; set; }
        public string Remarks { get; set; }
        public int Revision { get; set; }
        public bool Remotely { get; set; }
        public string RemotelyView { get; set; }
        public bool IsClosed { get; set; }
        public string IsClosedView { get; set; }
        public bool IsIndexed { get; set; }
        public string IsIndexedView { get; set; }
        public long TransferedTo { get; set; }
        public string TransferedToName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
