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

        private void SetSessionValue(string key, object value)
        {
            if (HttpContext.Current.Session == null) return;

            HttpContext.Current.Session[key] = value;
        }

        public string CurrentUserName { get { return this.GetSessionValue("UserName").AsString(); } }

        public int CurrentClientId { get { return this.GetSessionValue("ClientId").AsInt(); } }

        public int CurrentUserId { get { return this.GetSessionValue("UserId").AsInt(); } }

        public IEnumerable<string> CurrentUserRoleCodes { get { return this.GetSessionValue("Permissions") as IEnumerable<string> ?? new List<string>(); } }

        public string CurrentClientApiKey { get { return this.GetSessionValue("ClientApiKey").AsString(); } }

        public string CurrentLanguageCode
        {
            get
            {
                var sessionValue = this.GetSessionValue("CurrentLanguageCode").AsString();
                return  String.IsNullOrEmpty(sessionValue) ? "es" : sessionValue.AsString() ;
            }
            set
            {
                this.SetSessionValue("CurrentLanguageCode", value);
            }
        }
    }
}