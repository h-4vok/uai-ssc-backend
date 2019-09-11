using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class UserInvitationSignUpViewModel
    {
        public UserInvitation Invitation { get; set; }
        public string ClientName { get; set; }
        public string Password { get; set; }
    }
}