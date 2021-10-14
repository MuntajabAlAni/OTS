using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Users
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public bool State { get; set; }
        public string Ip { get; set; }
        public string Remarks { get; set; }
        public Guid Salt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
