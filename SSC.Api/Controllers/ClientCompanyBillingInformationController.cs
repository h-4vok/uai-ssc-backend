using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class ClientCompanyBillingInformationController : ApiController
    {
        private IClientCompanyBusiness business;

        public ClientCompanyBillingInformationController(IClientCompanyBusiness business) => this.business = business;

        public ResponseViewModel<ClientCompanyBillingInformation> Get() => throw new NotImplementedException();

        public ResponseViewModel Put(int id, ClientCompanyBillingInformation model) => throw new NotImplementedException();
    }
}