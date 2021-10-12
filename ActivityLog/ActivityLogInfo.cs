using OTS.Ticketing.Win.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.ActivityLog
{
    public class ActivityLogInfo
    {
        public ActivityLogInfo(ActivityType activity, long affectedId, string details = "")
        {
            UserId = SystemConstants.loggedInUser.Id;
            ActivityDate = DateTime.Now;
            ActivityType = (int)activity;
            ComputerName = Environment.MachineName;
            Details = details;
            AffectedId = affectedId;
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime ActivityDate { get; set; }
        public int ActivityType { get; set; }
        public string ComputerName { get; set; }
        public string Details { get; set; }
        public long AffectedId { get; set; }
    }
}
