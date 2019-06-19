using SSC.Api.ViewModels;
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
        public ResponseViewModel<AuthenticationResponseViewModel> Post(AuthenticationViewModel viewModel)
        {
            return null;
        }
    }
}