using SSC.Api.ViewModels;
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
    public class UserController : ApiController
    {
        public ResponseViewModel Post(EditUserViewModel viewModel)
        {
            var business = DependencyResolver.Obj.Resolve<IUserBusiness>();
            return null;
        }
    }
}