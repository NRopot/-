using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class TypesOfJobs
    {
        public TypesOfJobs()
        {
            Brigade = new HashSet<Brigade>();
            Works = new HashSet<Works>();
        }

        public int JobId { get; set; }
        public string NameWork { get; set; }
        public string Description { get; set; }
        public decimal? CostWork { get; set; }
        public int? MaterialId { get; set; }

        public Materials Material { get; set; }
        public ICollection<Brigade> Brigade { get; set; }
        public ICollection<Works> Works { get; set; }
    }
}
