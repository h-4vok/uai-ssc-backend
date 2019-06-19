using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class Role : AuditableEntity
    {
        public string Name { get; set; }
        public bool IsPlatformRole { get; set; }
        public IEnumerable<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
