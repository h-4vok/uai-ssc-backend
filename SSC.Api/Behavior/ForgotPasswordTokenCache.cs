using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Behavior
{
    public class ForgotPasswordTokenCache : IForgotPasswordTokenCache
    {
        private static readonly object locker = new object();
        private static readonly IDictionary<string, string> dict = new Dictionary<string, string>();

        public void Set(string token, string username)
        {
            lock (locker)
            {
                if (dict.ContainsKey(token))
                {
                    dict[token] = username;
                }
                else
                {
                    dict.Add(token, username);
                }
            }
        }

        public string Get(string token)
        {
            if (dict.ContainsKey(token))
            {
                return dict[token];
            }

            return String.Empty;
        }
    }
}