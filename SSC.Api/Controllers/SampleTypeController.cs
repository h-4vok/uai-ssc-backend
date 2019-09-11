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
    public class SampleTypeController : ApiController
    {
        private ISampleTypeBusiness business;

        public SampleTypeController(ISampleTypeBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<SampleTypeReportRow>> GetAll() => throw new NotImplementedException();

        public ResponseViewModel<SampleType> Get(int id) => throw new NotImplementedException();

        public ResponseViewModel<int> Post(SampleType model) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, SampleType model) => throw new NotImplementedException();

        public ResponseViewModel Delete(int id) => throw new NotImplementedException();
    }
}