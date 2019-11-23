using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class SampleController : ApiController
    {
        private ISampleBusiness business;

        public SampleController(ISampleBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<SampleReportRow>> Get(string functionCode, string typeCode)
            => this.business.GetAvailableSamples(functionCode, typeCode).ToList();
    }
}