using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Scheduling
{
    public class EmployeeInfo
    {
        public long Id { get; set; }
        public string EmployeeName { get; set; }
        public bool State { get; set; }
        public string Remarks { get; set; }
    }
}
