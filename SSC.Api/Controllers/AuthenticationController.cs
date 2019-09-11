using SSC.Api.ViewModels;
using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class AuthenticationController : ApiController
    {
        private IUserBusiness business;

        public AuthenticationController(IUserBusiness business) => this.business = business;

        public ResponseViewModel<AuthenticationResponseViewModel> Post(AuthenticationViewModel viewModel) => throw new NotImplementedException();
    }
}