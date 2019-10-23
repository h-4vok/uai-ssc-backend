using SSC.Api.ViewModels;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class ForgotPasswordController : ApiController
    {
        public class ForgotPasswordModel
        {
            public string UserName { get; set; }
            public string IncomingHost { get; set; }
        }

        private IUserBusiness business;

        public ForgotPasswordController(IUserBusiness business) => this.business = business;

        public ResponseViewModel Post(ForgotPasswordModel model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validation = Validator<ForgotPasswordModel>.Start(model)
                .MandatoryString(x => x.UserName, i10n["sign-up--initial.email"])
                .MinStringLength(x => x.UserName, i10n["sign-up--initial.email"], 6)
                .ValidEmailAddress(x => x.UserName, i10n["sign-up--initial.email"])
                .ValidationResult;

            if (!string.IsNullOrWhiteSpace(validation))
            {
                return validation;
            }

            try
            {
                this.business.SendForgottenPasswordRecovery(model.UserName, model.IncomingHost);
            }
            catch (UnprocessableEntityException ex)
            {
                return ex.Message;
            }

            return true;
        }

        public ResponseViewModel Get(string username, string token)
        {
            var isValid = this.business.IsRecoveryTokenValid(username, token);
            return isValid;
        }

        public ResponseViewModel Put(int id, PasswordRecoveryViewModel viewModel)
        {
            this.business.UpdatePassword(viewModel.UserName, viewModel.Password);

            return true;
        }
    }
}