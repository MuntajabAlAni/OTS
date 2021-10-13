namespace OTS.Ticketing.Win.Scheduling
{
    public class TaskView
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string TaskStart { get; set; }
        public string TaskEnd { get; set; }
        public bool TaskState { get; set; }
        public string TaskDetails { get; set; }
    }
}
