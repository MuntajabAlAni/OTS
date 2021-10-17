using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.UsersRoles
{
    public class RoleInfo
    {
        public long Id { get; set; }
        public string RoleName { get; set; }

        public long UserId { get; set; }
        public long RoleId { get; set; }

    }
}
