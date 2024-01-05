namespace InTimeCourier.Models
{
    using Domain.Master;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StateMaster")]
    public partial class StateMaster : BaseEntity<int>
    {

        [ForeignKey("CountryMaster")]
        public Nullable<int> CountryId { get; set; }

        [StringLength(150)]
        public string StateName { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime? CreatedDt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }

        [StringLength(5)]
        public string StateCode { get; set; }
        public CountryMaster CountryMaster { get; set; }
    }
}
