using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string CurrentPassword { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public string IncomingHost { get; set; }
    }
}
