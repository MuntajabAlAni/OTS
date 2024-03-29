﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.ActivityLog
{
    public class ActivityView
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ActivityType { get; set; }
        public string ComputerName { get; set; }
        public string Details { get; set; }
        public long AffectedId { get; set; }
    }
}
