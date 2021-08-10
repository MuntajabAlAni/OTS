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
        public long SoftwareId { get; set; }
        public long EmployeeId { get; set; }
        public long CompanyId { get; set; }
        public string Problem { get; set; }
        public long State { get; set; }
        public string Remarks { get; set; }
        public int Revision { get; set; }
        public bool Remotely { get; set; }
        public bool IsClosed { get; set; }

    }
}
