using SSC.Api.Behavior;
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

        [SscAuthorize(Permissions = "CLIENT_MANAGEMENT")]
        public ResponseViewModel Patch(int id, PatchOperationList list)
        {
            foreach (var operation in list.Operations)
            {
                if (operation.op == "replace" && operation.field == "IsEnabled")
                {
                    this.business.UpdateIsEnabled(operation.key, operation.value.AsBool());
                }
            }

            return true;
        }

    }
}