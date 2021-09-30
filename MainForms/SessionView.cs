using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.MainForms
{
    public class SessionView
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string DisplayName { get; set; }
        public int LastEvent { get; set; }
        public string ComputerName { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsOnline { get; set; }
        public string Number { get; set; }
    }
}
