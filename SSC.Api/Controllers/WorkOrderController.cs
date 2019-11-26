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

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();

        [HttpGet]
        [Route("{id}")]
        public ResponseViewModel<WorkOrder> Get(int id) => throw new NotImplementedException();

        [HttpPut]
        [Route("checkSamples/{id}")]
        public ResponseViewModel Put(int id, CheckSamplesWorkOrderViewModel model)
            => ResponseViewModel.RunAndReturn(() => this.business.CheckSamples(id, model.CheckedSamples));
    }
}