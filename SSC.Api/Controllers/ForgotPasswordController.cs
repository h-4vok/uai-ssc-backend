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
    public class ForgotPasswordController : ApiController
    {
        private IUserBusiness business;

        public ForgotPasswordController(IUserBusiness business) => this.business = business;

        public ResponseViewModel Post(string userName) => throw new NotImplementedException();

        public ResponseViewModel Get(PasswordRecoveryViewModel viewModel) => throw new NotImplementedException();

        public ResponseViewModel Put(string userName, PasswordRecoveryViewModel viewModel) => throw new NotImplementedException();
    }
}