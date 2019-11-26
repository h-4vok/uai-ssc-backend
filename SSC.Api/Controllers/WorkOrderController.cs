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
    [RoutePrefix("api/workorder")]
    public class WorkOrderController : ApiController
    {
        private IWorkOrderBusiness business;

        public WorkOrderController(IWorkOrderBusiness business) => this.business = business;

        [SscAuthorize(Permissions = "WORK_ORDER_REPORT")]
        [HttpGet]
        [Route("")]
        public ResponseViewModel<IEnumerable<WorkOrderReportRow>> Get()
            => this.business.GetReport().ToList();

        [HttpPost]
        [Route("")]
        public ResponseViewModel<int> Post(StartWorkOrderViewModel model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));

        [HttpPatch]
        [Route("{id}")]
        public ResponseViewModel Patch(int id, PatchOperationList list)
        {
            foreach (var operation in list.Operations)
            {
                if (operation.op == "replace" && operation.field == "WorkOrderStatusId")
                {
                    this.business.Cancel(operation.key);
                }
            }

            return true;
        }

        [HttpGet]
        [Route("expectedSamples/{id}")]
        public ResponseViewModel<IEnumerable<ExpectedSampleViewModel>> GetForExecution(int id)
            => this.business.GetExpectedSamples(id).ToList();

        [HttpPut]
        [Route("checkSamples/{id}")]
        public ResponseViewModel Put(int id, CheckSamplesWorkOrderViewModel model)
            => ResponseViewModel.RunAndReturn(() => this.business.CheckSamples(id, model.CheckedSamples));

        [HttpPut]
        [Route("finish/{id}")]
        public ResponseViewModel Put(int id, FinishWorkOrderViewModel model)
            => ResponseViewModel.RunAndReturn(() => this.business.Finish(id, model));
    }
}