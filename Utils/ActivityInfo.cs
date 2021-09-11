using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Utils
{
    public class ActivityInfo
    {
        public string DisplayName { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ActivityName { get; set; }
        public string ComputerName { get; set; }
        public string Details { get; set; }
        public long AffectedId { get; set; }
    }
}
