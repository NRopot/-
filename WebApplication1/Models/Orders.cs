using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Orders
    {
        public Orders()
        {
            Works = new HashSet<Works>();
        }

        public int OrderId { get; set; }
        public int? CustomersId { get; set; }
        public int? JobId { get; set; }
        public int? BrigadeId { get; set; }
        public decimal? Cost { get; set; }
        public string Brigadier { get; set; }
        public bool? PaymentNote { get; set; }
        public bool? CompletionNote { get; set; }
        public int? MaterialsId { get; set; }

        public Brigade Brigade { get; set; }
        public Customers Customers { get; set; }
        public Materials Materials { get; set; }
        public ICollection<Works> Works { get; set; }
    }
}
