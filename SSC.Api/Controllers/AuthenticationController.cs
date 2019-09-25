using SSC.Api.ViewModels;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common.Exceptions;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace SSC.Api.Controllers
{
    [System.Web.Http.AllowAnonymous]
    [System.Web.Mvc.SessionState(SessionStateBehavior.Required)]
    public class AuthenticationController : ApiController
    {
        private IUserBusiness business;

        public AuthenticationController(IUserBusiness business) => this.business = business;

        public ResponseViewModel<AuthenticationResponseViewModel> Post(AuthenticationViewModel viewModel)
        {
            var validations = Validator<AuthenticationViewModel>.Start(viewModel)
                .MandatoryString(x => x.UserName, "Nombre de usuario")
                .MandatoryString(x => x.Password, "Contraseña")
                .ValidationResult;

            if (!String.IsNullOrEmpty(validations))
                return validations;

            try
            {
                var response = this.business.Authenticate(viewModel.UserName, viewModel.Password);
                return response;
            }
            catch (UserAuthenticationException ex)
            {
                return ex.Message;
            }
        }
    }
}