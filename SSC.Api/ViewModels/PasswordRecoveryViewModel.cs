using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class PasswordRecoveryViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RecoveryToken { get; set; }
    }
}