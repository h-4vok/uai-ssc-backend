using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class WorkOrderBusiness : IWorkOrderBusiness
    {
        public WorkOrderBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IWorkOrderData>();
        }
        private IWorkOrderData data;

        public int Create(WorkOrder model)
        {
            throw new NotImplementedException();
        }

        public WorkOrder Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkOrderReportRow> GetReport(int clientId, string statusCode)
        {
            throw new NotImplementedException();
        }

        public void MarkAsChecked(int id, string sampleCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int id, string statusCode)
        {
            throw new NotImplementedException();
        }
    }
}
