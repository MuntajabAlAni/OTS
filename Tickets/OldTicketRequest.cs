using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Tickets
{
    public class OldTicketRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public int IsClosed { get; set; }
    }
}
