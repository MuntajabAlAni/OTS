using System;

namespace OTS.Ticketing.Win.Users
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool State { get; set; }
        public string Ip { get; set; }
        public string Remarks { get; set; }
        public Guid Salt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
