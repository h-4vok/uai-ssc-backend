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
    public class SessionController : ApiController
    {
        private IUserBusiness business;

        public SessionController(IUserBusiness business) => this.business = business;

        public ResponseViewModel Post(SessionViewModel model) => throw new NotImplementedException();

        public ResponseViewModel Delete(string id) => throw new NotImplementedException();
    }
}