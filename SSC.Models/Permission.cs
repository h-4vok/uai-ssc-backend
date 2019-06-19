using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class Permission : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
