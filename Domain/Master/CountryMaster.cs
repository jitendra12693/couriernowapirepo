global using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Master
{
    public class CountryMaster: BaseEntity<int>
    {
        
        public string CountryName { get; set; }
        public string Countinent     { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? UpdatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
