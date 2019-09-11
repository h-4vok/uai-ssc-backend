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
    public class SampleFunctionController : ApiController
    {
        private ISampleFunctionBusiness business;

        public SampleFunctionController(ISampleFunctionBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<SampleFunction>> Get() => throw new NotImplementedException();

        public ResponseViewModel<SampleFunction> Get(int id) => throw new NotImplementedException();

        public ResponseViewModel Post(SampleFunction model) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, SampleFunction model) => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();
    }
}