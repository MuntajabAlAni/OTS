using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Software.Models
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
        public long CustomerId { get; set; }
        public bool State { get; set; }
        public string Remarks { get; set; }
        public int Revision { get; set; }
    }
}
