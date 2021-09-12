﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.PhoneNumbers
{
    public class PhoneNumberView
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
