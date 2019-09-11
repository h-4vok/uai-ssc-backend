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
    public class WorkOrderController : ApiController
    {
        private IWorkOrderBusiness business;

        public WorkOrderController(IWorkOrderBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<WorkOrderReportRow>> GetReport(string statusCode) => throw new NotImplementedException();

        public ResponseViewModel<int> Post(WorkOrder model) => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();

        public ResponseViewModel<WorkOrder> Get(int id) => throw new NotImplementedException();
    }
}