using InTimeCourier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Master
{
    public class CompanyMaster:BaseEntity<int>
    {
        [Required]
        public string CompanyName { get; set; }
        
        public string CompanyUrl  { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        public string CompanyAddress { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        [ForeignKey("StateMaster")]
        public Nullable<int> StateId { get; set; }
        [ForeignKey("CountryMaster")]
        public Nullable<int> CountryId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public StateMaster StateMaster { get; set; }
        public CountryMaster CountryMaster { get; set; }
    }
}
