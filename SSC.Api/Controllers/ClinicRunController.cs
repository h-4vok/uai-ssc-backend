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
    public class ClinicRunController : ApiController
    {
        private IClinicRunBusiness business;

        public ClinicRunController(IClinicRunBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<ClinicRunReportRow>> Get() => throw new NotImplementedException();

        public ResponseViewModel Post(ClinicRun model) => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, IEnumerable<ClinicRunSampleResult> models) => throw new NotImplementedException();

        public ResponseViewModel Post(ClinicRunExecution model) => throw new NotImplementedException();
    }
}