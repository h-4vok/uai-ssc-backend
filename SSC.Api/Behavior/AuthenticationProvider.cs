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

        public int CurrentClientId => HttpContext.Current.Session["ClientId"].AsInt();

        public int CurrentUserId => HttpContext.Current.Session["UserId"].AsInt();

        public IEnumerable<string> CurrentUserRoleCodes => HttpContext.Current.Session["Permissions"] as IEnumerable<string> ?? new List<string>();

        public string CurrentClientApiKey => HttpContext.Current.Session["ClientApiKey"].AsString();
    }
}