using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IWorkOrderData
    {
        IEnumerable<WorkOrderReportRow> GetReport();
        int Create(WorkOrder model);
        void UpdateStatus(int id, string statusCode);
        WorkOrder Get(int id);
        void AssignTo(int id, int userId);
        void MarkAsChecked(int workOrderId, IEnumerable<int> sampleIds);
        IEnumerable<ExpectedSampleViewModel> GetExpectedSamples(int workOrderId);
        void Finish(int id, IEnumerable<ExpectedSampleViewModel> aliquots);
    }
}
