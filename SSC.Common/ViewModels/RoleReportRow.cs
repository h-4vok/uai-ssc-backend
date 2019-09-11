using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class RoleReportRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityOfUsers { get; set; }
        public int QuantityOfPermissions { get; set; }
        public bool IsEnabled { get; set; }
    }
}
