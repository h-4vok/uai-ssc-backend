using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class ClientLandingController : ApiController
    {
        public ClientLandingController(IClientManagementBusiness business) => this.business = business;

        protected IClientManagementBusiness business;

        public ResponseViewModel<ClientLandingViewModel> Get() => this.business.GetLandingData();
    }
}