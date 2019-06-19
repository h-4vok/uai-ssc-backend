using SSC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class AuditRecord
    {
        public AuditRecord()
        {
            this.CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public AuditRecordEnum RecordType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
