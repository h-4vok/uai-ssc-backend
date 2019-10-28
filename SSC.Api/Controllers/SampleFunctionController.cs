using SSC.Api.Behavior;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
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

        [SscAuthorize(Permissions = "SAMPLE_TYPE_REPORT,SAMPLE_TYPE_MANAGEMENT")]
        public ResponseViewModel<IEnumerable<SampleFunction>> Get() => this.business.GetAll().ToList();

        [SscAuthorize(Permissions = "SAMPLE_TYPE_MANAGEMENT")]
        public ResponseViewModel<SampleFunction> Get(int id) => this.business.Get(id);

        [SscAuthorize(Permissions = "SAMPLE_TYPE_MANAGEMENT")]
        public ResponseViewModel Post(SampleFunction model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));

        [SscAuthorize(Permissions = "SAMPLE_TYPE_MANAGEMENT")]
        public ResponseViewModel Put(int id, SampleFunction model) => ResponseViewModel.RunAndReturn(() => this.business.Update(model));

        [SscAuthorize(Permissions = "SAMPLE_TYPE_MANAGEMENT")]
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