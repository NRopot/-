using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Works
    {
        public int WorkId { get; set; }
        public int? JobId { get; set; }
        public int? OrderId { get; set; }
        public int? BrigadeId { get; set; }
        public DateTime? DateBeginning { get; set; }
        public DateTime? DateEnd { get; set; }
        public string FioBrigadier { get; set; }

        public Brigade Brigade { get; set; }
        public TypesOfJobs Job { get; set; }
        public Orders Order { get; set; }
    }
}
