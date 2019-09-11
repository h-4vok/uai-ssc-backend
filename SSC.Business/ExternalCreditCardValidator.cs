using SSC.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class ExternalCreditCardValidator : IExternalCreditCardValidator
    {
        public string Validate(string number, string ccv, string owner, string expiration)
        {
            throw new NotImplementedException();
        }
    }
}
