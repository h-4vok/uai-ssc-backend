using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Behavior
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private object GetSessionValue(string key)
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }

            return HttpContext.Current.Session[key];
        }

        public string CurrentUserName => this.GetSessionValue("UserName").AsString();

        public int CurrentClientId => this.GetSessionValue("ClientId").AsInt();

        public int CurrentUserId => this.GetSessionValue("UserId").AsInt();

        public IEnumerable<string> CurrentUserRoleCodes => this.GetSessionValue("Permissions") as IEnumerable<string> ?? new List<string>();

        public string CurrentClientApiKey => this.GetSessionValue("ClientApiKey").AsString();
    }
}