using System;

namespace OTS.Ticketing.Win.MainForms
{
    public class SessionView
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string DisplayName { get; set; }
        public string EventName { get; set; }
        public string ComputerName { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsOnline { get; set; }
        public string Number { get; set; }
        public Guid SessionId { get; set; }
    }
}
