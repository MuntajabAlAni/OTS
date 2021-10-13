using OTS.Ticketing.Win.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.MainForms
{
    public class SessionInfo
    {
        public SessionInfo(EventType eventType = 0)
        {
            UserId = SystemConstants.loggedInUser.Id;
            LastEvent = (int)eventType;
            ComputerName = Environment.MachineName;
            SessionId = SystemConstants.loggedInUserSessionId;
        }
        public long Id { get; set; }
        public long UserId { get; set; }
        public long LastEvent { get; set; }
        public string ComputerName { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsOnline { get; set; }
        public string Number { get; set; }
        public Guid SessionId { get; set; }
    }
}
