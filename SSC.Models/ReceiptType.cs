using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ReceiptType : AuditableEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsSale { get; set; }
    }
}
