using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IWorkOrderBusiness
    {
        IEnumerable<WorkOrderReportRow> GetReport();
        int Create(StartWorkOrderViewModel model);
        void UpdateStatus(int id, string statusCode);
        WorkOrder Get(int id);
        void MarkAsChecked(int id, string sampleCode);
        void CheckSamples(int workOrderId, IEnumerable<CheckableSampleReportRow> checkedSamples);
        IEnumerable<ExpectedSampleViewModel> GetExpectedSamples(int workOrderId);
        void Finish(int id, FinishWorkOrderViewModel model);
        void Cancel(int id);
    }
}
