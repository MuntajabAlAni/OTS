using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.ActivityLog
{
    public class ActivityLogReportInfo
    {
        public long UserId { get; set; }
        public long ActivityId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
