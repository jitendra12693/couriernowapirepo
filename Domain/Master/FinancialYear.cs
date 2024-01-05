using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InTimeCourier.Models
{
    [Table("FinancialYear")]
    public class FinancialYear : BaseEntity<int>
    {
        public string FYear { get; set; }
        public bool IsActive { get; set; }
    }
}