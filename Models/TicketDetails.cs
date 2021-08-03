﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Software.Models
{
    public class TicketDetails
    {
        public long Number { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string PhoneNumber { get; set; }
        public string SoftwareName { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public string State { get; set; }
        public int Revision { get; set; }
    }
}
