using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Behavior
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        public string CurrentUserName => HttpContext.Current.Session["UserName"].AsString();
    }
}