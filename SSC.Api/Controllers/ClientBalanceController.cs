using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class ClientBalanceController : ApiController
    {
        private IClientCompanyBusiness business;

        public ClientBalanceController(IClientCompanyBusiness business) => this.business = business;

        public ResponseViewModel<ClientBalanceReport> Get(int id) => throw new NotImplementedException();
    }
}