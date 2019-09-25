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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ClientCompany ClientCompany { get; set; }
        public IEnumerable<Phone> Phones { get; set; } = new List<Phone>();
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
        public string TitleInCompany { get; set; }
        public bool IsEnabledInCompany { get; set; }
        public int LoginFailures { get; set; }

        public IEnumerable<Permission> GetGrantedPermissions()
        {
            var output =
                (this.Roles ?? new List<Role>())
                .SelectMany(x => x.Permissions)
                .Distinct(x => x.Code)
                .ToList();

            return output;
        }
    }
}
