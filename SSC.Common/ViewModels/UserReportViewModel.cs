using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class UserReportViewModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsBlocked { get; set; }
        public int CountOfRoles { get; set; }
        public int CountOfPermissions { get; set; }
        public bool IsPlatformAdmin { get; set; }
    }
}
