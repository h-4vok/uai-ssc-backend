using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    [RoutePrefix("api/sample")]
    public class SampleController : ApiController
    {
        private ISampleBusiness business;

        public SampleController(ISampleBusiness business) => this.business = business;

        [Route("")]
        [HttpGet]
        public ResponseViewModel<IEnumerable<SampleReportRow>> Get()
            => this.business.GetAvailableSamples().ToList();

        [Route("parentSamplesOfWorkOrder/{workOrderId}")]
        public ResponseViewModel<IEnumerable<CheckableSampleReportRow>> Get(int workOrderId) =>
            this.business.GetParentSamplesOfWorkOrder(workOrderId).ToList();
    }
}