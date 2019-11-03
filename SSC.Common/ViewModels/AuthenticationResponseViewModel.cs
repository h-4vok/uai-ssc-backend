using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class AuthenticationResponseViewModel
    {
        public IEnumerable<string> GrantedPermissions { get; set; } = new List<string>();
        public string SetCookie { get; set; }
        public IEnumerable<PlatformMenu> Menues { get; set; }
    }
}
