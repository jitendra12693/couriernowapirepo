using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Master
{
    public class InvoiceSerialNumber:BaseEntity<long>
    {
        public int? InvoiceSrNo { get; set; }
        public string? InvoiceFormat { get; set; }
        public int? InvoiceYear { get; set; }
        public bool? IsActive { get; set; }
        public int? BillId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
