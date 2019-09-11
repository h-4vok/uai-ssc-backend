using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        public string CurrentUserName => throw new NotImplementedException();

        public int CurrentClientId => throw new NotImplementedException();

        public int CurrentUserId => throw new NotImplementedException();

        public IEnumerable<string> CurrentUserRoleCodes => throw new NotImplementedException();

        public string CurrentClientApiKey => throw new NotImplementedException();
    }
}
