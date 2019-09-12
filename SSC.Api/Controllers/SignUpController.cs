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

        //public ResponseViewModel ValidateNewSignUp(UserBusiness user) => throw new NotImplementedException();

        public ResponseViewModel Post(SignUpValidationViewModel model)
        {
            string Initial_Validation()
            {
                var partial = Validator<SignUpValidationViewModel>.Start(model)
                    .MandatoryString(x => x.FirstName, "Nombre")
                    .MaxStringLength(x => x.FirstName, "Nombre", 200)
                    .MandatoryString(x => x.LastName, "Apellido")
                    .MaxStringLength(x => x.LastName, "Apellido", 200)
                    .MandatoryString(x => x.UserName, "Email")
                    .MinStringLength(x => x.UserName, "Email", 6)
                    .ValidEmailAddress(x => x.UserName, "Email")
                    .MandatoryString(x => x.Password, "Contraseña")
                    .ValidationResult;

                if (!String.IsNullOrWhiteSpace(partial))
                    return partial;

                var business = DependencyResolver.Obj.Resolve<IUserBusiness>();
                partial = business.PreValidateNewUser(model.UserName, model.Password);

                return partial;
            };

            string Company_Validation()
            {
                var partial = Validator<SignUpValidationViewModel>.Start(model)
                    .NotNull(x => x.CompanyData, "Compañía")
                    .MandatoryString(x => x.CompanyData.Name, "Nombre de la empresa")
                    .MaxStringLength(x => x.CompanyData.Name, "Nombre de la empresa", 200)
                    .MandatoryDropdownSelection(x => x.CompanyData.ProvinceId, "Provincia")
                    .MandatoryString(x => x.CompanyData.City, "Ciudad")
                    .MaxStringLength(x => x.CompanyData.City, "Ciudad", 200)
                    .MandatoryString(x => x.CompanyData.StreetName, "Calle")
                    .MaxStringLength(x => x.CompanyData.StreetName, "Calle", 500)
                    .MandatoryString(x => x.CompanyData.Number, "Número")
                    .MaxStringLength(x => x.CompanyData.Number, "Número", 35)
                    .MandatoryString(x => x.CompanyData.Department, "Departamento")
                    .MaxStringLength(x => x.CompanyData.Department, "Departamento", 35)
                    .MandatoryString(x => x.CompanyData.PostalCode, "Código Postal")
                    .MaxStringLength(x => x.CompanyData.PostalCode, "Código Postal", 35)
                    .ValidationResult;

                if (!String.IsNullOrWhiteSpace(partial))
                    return partial;

                var business = DependencyResolver.Obj.Resolve<IUserBusiness>();
                partial = business.ValidateNewUserSignUp(model.CompanyData.Name, null);

                return partial;
            }

            var validators = new Dictionary<SignUpValidationStep, Func<string>>
            {
                { SignUpValidationStep.Initial, Initial_Validation },
                { SignUpValidationStep.Company, Company_Validation }
            };

            var currentValidator = validators[model.Step];
            var validation = currentValidator();

            if (!String.IsNullOrWhiteSpace(validation))
                return validation;

            return true;
        }
    }
}