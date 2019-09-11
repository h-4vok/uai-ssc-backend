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
    public class SampleTransactionController : ApiController
    {
        private ISampleTransactionBusiness business;

        public SampleTransactionController(ISampleTransactionBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<SampleTransactionReportRow>> GetReport(int sampleId) => throw new NotImplementedException();

        public ResponseViewModel<SampleTransaction> Get(int id) => throw new NotImplementedException();

        public ResponseViewModel Post(SampleTransaction model) => throw new NotImplementedException();
    }
}