namespace InTimeCourier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("CourrierMode")]
    public partial class CourrierMode:BaseEntity<int>
    {

        [StringLength(50)]
        public string CourrierModeName { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
