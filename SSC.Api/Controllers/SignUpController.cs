using SSC.Api.ViewModels;
using SSC.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class SignUpController : ApiController
    {
        public ResponseViewModel Get(SignUpValidationViewModel model)
        {
            return null;
        }

        public ResponseViewModel ValidateModel(SignUpValidationViewModel model)
        {
            var validation = Validator<SignUpValidationViewModel>.Start(model)
                .MandatoryString(x => x.FirstName, "Nombre")
                .MaxStringLength(x => x.FirstName, "Nombre", 200)
                .MandatoryString(x => x.FirstName, "Apellido")
                .MaxStringLength(x => x.FirstName, "Nombre", 200)
                .MandatoryString(x => x.UserName, "Email")
                .MinStringLength(x => x.UserName, "Email", 6)
                .ValidEmailAddress(x => x.UserName, "Email")
                .MandatoryString(x => x.Password, "Contraseña")
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validation))
                return validation;

            var business = new UserBusiness();
            validation = business.PreValidateNewUser(model.UserName, model.Password);

            if (!String.IsNullOrWhiteSpace(validation))
                return validation;

            return true;
        }
    }
}