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
    public class SampleParameterTypeController : ApiController
    {
        private ISampleParameterTypeBusiness business;

        public SampleParameterTypeController(ISampleParameterTypeBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<SampleTypeParameterReportRow>> Get() => throw new NotImplementedException();

        public ResponseViewModel<SampleTypeParameter> Get(int id) => throw new NotImplementedException();

        public ResponseViewModel Post(SampleTypeParameter model) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, SampleTypeParameter model) => throw new NotImplementedException();

        public ResponseViewModel Delete(int id) => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();
    }
}