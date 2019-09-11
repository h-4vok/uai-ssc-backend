using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IExternalCreditCardValidator
    {
        string Validate(string number, string ccv, string owner, string expiration);
    }
}
