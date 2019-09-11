using DBNostalgia;
using SSC.Common;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class WorkOrderData : IWorkOrderData
    {
        public WorkOrderData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private WorkOrderReportRow FetchReportRow(IDataReader reader) => throw new NotImplementedException();

        private WorkOrder Fetch(IDataReader reader) => throw new NotImplementedException();

        private void GatherParentSamples(IEnumerable<WorkOrder> models) => throw new NotImplementedException();

        private void GatherExpectedSamples(IEnumerable<WorkOrder> models) => throw new NotImplementedException();

        private Sample FetchSampleIntoParents(IDataReader reader) => throw new NotImplementedException();

        private WorkOrderExpectedSample FetchSampleIntoExpectedSample(IDataReader reader) => throw new NotImplementedException();

        public void AssignTo(int id, int userId)
        {
            throw new NotImplementedException();
        }

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
