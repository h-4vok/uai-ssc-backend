using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface IAuthenticationProvider
    {
        string CurrentUserName { get; }
        int CurrentClientId { get; }
        int CurrentUserId { get; }
        IEnumerable<string> CurrentUserRoleCodes { get; }
        string CurrentClientApiKey { get; }

        string CurrentLanguageCode { get; set; }
    }
}
