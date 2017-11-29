using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Materials
    {
        public Materials()
        {
            Orders = new HashSet<Orders>();
            TypesOfJobs = new HashSet<TypesOfJobs>();
        }

        public int MaterialId { get; set; }
        public string NameMaterial { get; set; }
        public string Packing { get; set; }
        public string Description { get; set; }
        public decimal? MaterialPrice { get; set; }

        public ICollection<Orders> Orders { get; set; }
        public ICollection<TypesOfJobs> TypesOfJobs { get; set; }
    }
}
