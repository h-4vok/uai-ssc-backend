using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface IForgotPasswordTokenCache
    {
        void Set(string token, string userName);
        string Get(string token);
    }
}
