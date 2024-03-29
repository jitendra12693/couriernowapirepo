namespace InTimeCourier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StatusMaster")]
    public partial class StatusMaster : BaseEntity<int>
    {

        public int? SubStatusId { get; set; }

        [StringLength(150)]
        public string StatusName { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedDt { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }
    }
}
