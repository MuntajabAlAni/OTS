using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Companies
{
    public class CompanyView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string BranchName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
