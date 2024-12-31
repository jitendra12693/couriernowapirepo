using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Master
{
    [Table("AppLogs")]
    public class ApplicationLog
    {
        [Key]
        public long AppLogId { get; set; }
        public string LogType { get; set; }
        [ForeignKey("CompanyMaster")]
        public Nullable<int> CompanyId { get; set; }
        public CompanyMaster CompanyMaster { get; set; }
        public string LogInformation { get; set; }
        public string LogTrace { get; set; }
        [ForeignKey("UserMaster")]
        public int UserId { get; set; }
        public DateTime LogDate { get; set; }
        public string SystemIP { get; set; }
    }
}
