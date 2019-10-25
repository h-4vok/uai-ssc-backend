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
    public class ClientCompanyController : ApiController
    {
        private IClientCompanyBusiness business;

        public ClientCompanyController(IClientCompanyBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<ClientCompanyReportRow>> Get()
        {
            var output = this.business.GetAll();
            return output.ToList();
        }

        public ResponseViewModel Post(ClientCompany model) => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();

    }
}