using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class User : AuditableEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<Role> Roles { get; set; } = new List<Role>();
        public bool IsBlocked { get; set; }
        public bool IsDisabled { get; set; }
        public ClientCompany ClientCompany { get; set; }

        public IEnumerable<Permission> GetGrantedPermissions()
        {
            throw new NotImplementedException();
        }
    }
}
