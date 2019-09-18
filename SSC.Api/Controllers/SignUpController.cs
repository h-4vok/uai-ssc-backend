using SSC.Api.ViewModels;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
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

            string Payment_Validation()
            {
                var creditCard = new CreditCard
                {
                    Number = model.CreditCardNumber,
                    Owner = model.CreditCardOwner,
                    ExpirationDateMMYY = model.CreditCardExpirationDateMMYY,
                    CCV = model.CreditCardCCV,
                };

                var creditCardController = new CreditCardController(DependencyResolver.Obj.Resolve<ICreditCardBusiness>());
                var creditCardResponse = creditCardController.Validate(creditCard);

                if (creditCardResponse.IsError)
                    return creditCardResponse.ErrorMessage;

                return String.Empty;
            }

            string Billing_Validation()
            {
                var partial = Validator<SignUpValidationViewModel>.Start(model)
                    .MandatoryString(x => x.BillingCompanyName, "Nombre de la empresa")
                    .MaxStringLength(x => x.BillingCompanyName, "Nombre de la empresa", 200)
                    .MandatoryString(x => x.BillingCompanyIdentification, "Número de identificación fiscal")
                    .MinStringLength(x => x.BillingCompanyIdentification, "Número de identificación fiscal", 11)
                    .MaxStringLength(x => x.BillingCompanyIdentification, "Número de identificación fiscal", 11)
                    .IsNumber(x => x.BillingCompanyIdentification, "Número de identificación fiscal")
                    .MandatoryDropdownSelection(x => x.BillingProvinceId, "Provincia")
                    .MandatoryString(x => x.BillingCity, "Ciudad")
                    .MaxStringLength(x => x.BillingCity, "Ciudad", 200)
                    .MandatoryString(x => x.BillingStreet, "Calle")
                    .MaxStringLength(x => x.BillingStreet, "Calle", 500)
                    .MandatoryString(x => x.BillingStreetNumber, "Número")
                    .MaxStringLength(x => x.BillingStreetNumber, "Número", 35)
                    .MandatoryString(x => x.BillingDepartment, "Departamento")
                    .MaxStringLength(x => x.BillingDepartment, "Departamento", 35)
                    .MandatoryString(x => x.BillingPostalCode, "Código Postal")
                    .MaxStringLength(x => x.BillingPostalCode, "Código Postal", 35)
                    .ValidationResult;

                return partial;
            }

            var validators = new Dictionary<SignUpValidationStep, Func<string>>
            {
                { SignUpValidationStep.Initial, Initial_Validation },
                { SignUpValidationStep.Company, Company_Validation },
                { SignUpValidationStep.Pricing, () => "" },
                { SignUpValidationStep.Payment, Payment_Validation },
                { SignUpValidationStep.Billing, Billing_Validation },
            };

            var currentValidator = validators[model.Step];
            var validation = currentValidator();

            if (!String.IsNullOrWhiteSpace(validation))
                return validation;

            return true;
        }

        public ResponseViewModel Put(int id, CompleteSignUpViewModel vm)
        {
            var partial = Validator<CompleteSignUpViewModel>.Start(vm)
                .NotNull(x => x.User, "Usuario")
                .NotNull(x => x.ClientCompany, "Empresa")
                .NotNull(x => x.ClientCompany.DefaultCreditCard, "Tarjeta de Crédito")
                .NotNull(x => x.ClientCompany.BillingInformation, "Datos de facturación")
                .NotNull(x => x.ClientCompany.Addresses.FirstOrDefault(), "Domicilio")
                .NotNull(x => x.ClientCompany.Addresses.First().Province, "Selección de Provincia")
                .NotNull(x => x.ClientCompany.BillingInformation, "Datos de Facturación")
                .MandatoryString(x => x.User.FirstName, "Nombre")
                .MaxStringLength(x => x.User.FirstName, "Nombre", 200)
                .MandatoryString(x => x.User.LastName, "Apellido")
                .MaxStringLength(x => x.User.LastName, "Apellido", 200)
                .MandatoryString(x => x.User.UserName, "Email")
                .MinStringLength(x => x.User.UserName, "Email", 6)
                .ValidEmailAddress(x => x.User.UserName, "Email")
                .MandatoryString(x => x.User.Password, "Contraseña")
                .MandatoryString(x => x.ClientCompany.Name, "Nombre de la empresa")
                .MaxStringLength(x => x.ClientCompany.Name, "Nombre de la empresa", 200)
                .MandatoryDropdownSelection(x => x.ClientCompany.Addresses.First().Province.Id, "Provincia")
                .MandatoryString(x => x.ClientCompany.Addresses.First().City, "Ciudad")
                .MaxStringLength(x => x.ClientCompany.Addresses.First().City, "Ciudad", 200)
                .MandatoryString(x => x.ClientCompany.Addresses.First().StreetName, "Calle")
                .MaxStringLength(x => x.ClientCompany.Addresses.First().StreetName, "Calle", 500)
                .MandatoryString(x => x.ClientCompany.Addresses.First().StreetNumber, "Número")
                .MaxStringLength(x => x.ClientCompany.Addresses.First().StreetNumber, "Número", 35)
                .MandatoryString(x => x.ClientCompany.Addresses.First().Department, "Departamento")
                .MaxStringLength(x => x.ClientCompany.Addresses.First().Department, "Departamento", 35)
                .MandatoryString(x => x.ClientCompany.Addresses.First().PostalCode, "Código Postal")
                .MaxStringLength(x => x.ClientCompany.Addresses.First().PostalCode, "Código Postal", 35)
                .MandatoryString(x => x.ClientCompany.BillingInformation.LegalName, "Denominación Fiscal")
                .MaxStringLength(x => x.ClientCompany.BillingInformation.LegalName, "Denominación Fiscal", 200)
                .MandatoryString(x => x.ClientCompany.BillingInformation.TaxCode, "Número de identificación fiscal")
                .MinStringLength(x => x.ClientCompany.BillingInformation.TaxCode, "Número de identificación fiscal", 11)
                .MaxStringLength(x => x.ClientCompany.BillingInformation.TaxCode, "Número de identificación fiscal", 11)
                .IsNumber(x => x.ClientCompany.BillingInformation.TaxCode, "Número de identificación fiscal")
                .MandatoryDropdownSelection(x => x.ClientCompany.BillingInformation.Address.Province.Id, "Provincia")
                .MandatoryString(x => x.ClientCompany.BillingInformation.Address.City, "Ciudad")
                .MaxStringLength(x => x.ClientCompany.BillingInformation.Address.City, "Ciudad", 200)
                .MandatoryString(x => x.ClientCompany.BillingInformation.Address.StreetName, "Calle")
                .MaxStringLength(x => x.ClientCompany.BillingInformation.Address.StreetName, "Calle", 500)
                .MandatoryString(x => x.ClientCompany.BillingInformation.Address.StreetNumber, "Número")
                .MaxStringLength(x => x.ClientCompany.BillingInformation.Address.StreetNumber, "Número", 35)
                .MandatoryString(x => x.ClientCompany.BillingInformation.Address.Department, "Departamento")
                .MaxStringLength(x => x.ClientCompany.BillingInformation.Address.Department, "Departamento", 35)
                .MandatoryString(x => x.ClientCompany.BillingInformation.Address.PostalCode, "Código Postal")
                .MaxStringLength(x => x.ClientCompany.BillingInformation.Address.PostalCode, "Código Postal", 35)
                .ValidationResult;

            var creditCard = new CreditCard
            {
                Number = vm.ClientCompany.DefaultCreditCard.Number,
                Owner = vm.ClientCompany.DefaultCreditCard.Owner,
                ExpirationDateMMYY = vm.ClientCompany.DefaultCreditCard.ExpirationDateMMYY,
                CCV = vm.ClientCompany.DefaultCreditCard.CCV
            };

            var creditCardController = new CreditCardController(DependencyResolver.Obj.Resolve<ICreditCardBusiness>());
            var creditCardResponse = creditCardController.Validate(creditCard);

            if (creditCardResponse.IsError)
                return creditCardResponse.ErrorMessage;

            var companyId = this.companyBusiness.Create(vm.ClientCompany);

            vm.ClientCompany.Id = companyId;
            vm.User.ClientCompany = vm.ClientCompany;

            this.business.Create(vm.User);

            return true;
        }
    }
}