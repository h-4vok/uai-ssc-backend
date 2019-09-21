using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Behavior
{
    public class VerificationCodeHandler : IVerificationCodeHandler
    {
        private static readonly object locker = new object();
        private static readonly IDictionary<string, int> AppVerificationCodes = new Dictionary<string, int>();

        public void Set(string userName, int verificationCode)
        {
            lock (locker)
            {
                if (AppVerificationCodes.ContainsKey(userName))
                {
                    AppVerificationCodes[userName] = verificationCode;
                }
                else
                {
                    AppVerificationCodes.Add(userName, verificationCode);
                }
            }
        }

        public int Get(string userName)
        {
            if (AppVerificationCodes.ContainsKey(userName))
            {
                return AppVerificationCodes[userName];
            }

            return -1;
        }
    }
}