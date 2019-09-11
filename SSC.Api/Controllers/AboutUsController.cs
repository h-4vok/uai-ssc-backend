using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class AboutUsController : ApiController
    {
        private IAboutUsBusiness business = DependencyResolver.Obj.Resolve<IAboutUsBusiness>();

        public ResponseViewModel<AboutUsViewModel> Get() => throw new NotImplementedException();
    }
}