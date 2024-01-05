using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Master
{
    public class CompanyDetail:BaseEntity<int>
    {
        [ForeignKey("CompanyMaster")]
        public Nullable<int> CompanyId { get; set; }

        public CompanyMaster CompanyMaster { get; set; }

        public string CompanyLogo { get; set; }
        public string CompanySignature { get; set; }
        public string AadharNo { get; set;}
        public string PanNumber { get; set; }
        public string AlternateContact { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankAddress { get; set; }
        public string IFSCCode { get; set; }
        public string AccountNo { get; set; }
        public string GSTINNo { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
