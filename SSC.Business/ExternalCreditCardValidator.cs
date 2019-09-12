using SSC.Business.Interfaces;
using SSC.Models;
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
            return Validator<CreditCard>.Start(
                new CreditCard
                {
                    Number = number,
                    CCV = ccv.AsInt(),
                    Owner = owner,
                    ExpirationDateMMYY = expiration
                })
                .MandatoryString(x => x.Number, "Número de tarjeta de crédito")
                .MinStringLength(x => x.Number, "Número de tarjeta de crédito", 16)
                .MaxStringLength(x => x.Number, "Número de tarjeta de crédito", 19)
                .IsNumber(x => x.Number, "Número de tarjeta de crédito")
                .MandatoryString(x => x.Owner, "Titular")
                .MaxStringLength(x => x.Owner, "Titular", 200)
                .MandatoryString(x => x.CCV.AsString(), "CCV")
                .MinStringLength(x => x.CCV.AsString(), "CCV", 3)
                .MaxStringLength(x => x.CCV.AsString(), "CCV", 4)
                .MandatoryString(x => x.ExpirationDateMMYY, "Fecha de Expiración")
                .MinStringLength(x => x.ExpirationDateMMYY, "Fecha de Expiración", 4)
                .MaxStringLength(x => x.ExpirationDateMMYY, "Fecha de Expiración", 4)
                .DateFormat(x => x.ExpirationDateMMYY, "Fecha de Expiración", "MMyy")
                .ValidationResult;
        }
    }
}
