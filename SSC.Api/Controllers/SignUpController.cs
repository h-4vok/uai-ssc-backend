using SSC.Api.ViewModels;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class SignUpController : ApiController
    {
        private IUserBusiness business;
        private IClientCompanyBusiness companyBusiness;

        public SignUpController(IUserBusiness business, IClientCompanyBusiness companyBusiness)
        {
            this.business = business;
            this.companyBusiness = companyBusiness;
        }

        public ResponseViewModel Get(SignUpValidationViewModel model)
        {
            return null;
        }

        public ResponseViewModel ValidateNewSignUp(UserBusiness user) => throw new NotImplementedException();

        public ResponseViewModel Post(SignUpValidationViewModel model)
        {
            var validation = Validator<SignUpValidationViewModel>.Start(model)
                .MandatoryString(x => x.FirstName, "Nombre")
                .MaxStringLength(x => x.FirstName, "Nombre", 200)
                .MandatoryString(x => x.LastName, "Apellido")
                .MaxStringLength(x => x.LastName, "Apellido", 200)
                .MandatoryString(x => x.UserName, "Email")
                .MinStringLength(x => x.UserName, "Email", 6)
                .ValidEmailAddress(x => x.UserName, "Email")
                .MandatoryString(x => x.Password, "Contraseña")
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validation))
                return validation;

            var business = DependencyResolver.Obj.Resolve<IUserBusiness>();
            validation = business.PreValidateNewUser(model.UserName, model.Password);

            if (!String.IsNullOrWhiteSpace(validation))
                return validation;

            return true;
        }
    }
}