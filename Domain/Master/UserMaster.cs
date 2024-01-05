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
    public class UserMaster:BaseEntity<int>
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [ForeignKey("RoleMaster")]
        public Nullable<int> RoleId { get; set; }
        public RoleMaster RoleMaster { get; set; }
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
