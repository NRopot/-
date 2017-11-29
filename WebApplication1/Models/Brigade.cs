using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Brigade
    {
        public Brigade()
        {
            Orders = new HashSet<Orders>();
            Works = new HashSet<Works>();
        }

        public int BrigadeId { get; set; }
        public string NameBrigade { get; set; }
        public string FioBrigadier { get; set; }
        public string CompositionWorker { get; set; }
        public int? JobId { get; set; }

        public TypesOfJobs Job { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Works> Works { get; set; }
    }
}
