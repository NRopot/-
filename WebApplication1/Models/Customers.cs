using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FioCustomer { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string PassportData { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
