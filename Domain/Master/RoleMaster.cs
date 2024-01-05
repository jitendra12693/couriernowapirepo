namespace InTimeCourier.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RoleMaster")]
    public partial class RoleMaster : BaseEntity<int>
    {

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDt { get; set; }
    }
}
