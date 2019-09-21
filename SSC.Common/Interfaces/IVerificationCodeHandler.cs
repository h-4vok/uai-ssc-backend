using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface IVerificationCodeHandler
    {
        void Set(string userName, int verificationCode);
        int Get(string userName);
    }
}
