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
    public class SampleBatchController : ApiController
    {
        private ISampleBatchBusiness business;

        public SampleBatchController(ISampleBatchBusiness business) => this.business = business;

        public ResponseViewModel Post(SampleBatch model) => throw new NotImplementedException();

        public ResponseViewModel<IEnumerable<SampleBatchReportRow>> Get() => throw new NotImplementedException();

        public ResponseViewModel<IEnumerable<SampleReportRow>> Get(int id) => throw new NotImplementedException();
    }
}