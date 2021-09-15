using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Scheduling
{
    public class TaskInfo
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string TaskDetails { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskStart { get; set; }
        public string TaskEnd { get; set; }
        public bool TaskState { get; set; }
        public bool IsDeleted { get; set; }
    }
}
