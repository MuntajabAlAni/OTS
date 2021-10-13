using System;

namespace OTS.Ticketing.Win.Scheduling
{
    public class TaskInfo
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long CompanyId { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskStart { get; set; }
        public string TaskEnd { get; set; }
        public bool TaskState { get; set; }
        public string TaskDetails { get; set; }

        public bool IsDeleted { get; set; }
    }
}
