using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Tickets
{
    public class TicketsView
    {
        public long Number { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string PhoneNumber { get; set; }
        public string SoftwareName { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string Problem { get; set; }
        public string State { get; set; }
        public int Revision { get; set; }
        public string Remarks { get; set; }
        public string Arrangement { get; set; }
        public string IsClosed { get; set; }
    }
}
