using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class UserInvitation : AuditableEntity
    {
        public ClientCompany Client { get; set; }
        public string InvitationToken { get; set; }
        public string Email { get; set; }
        public Role DefaultRole { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Used { get; set; }
    }
}
