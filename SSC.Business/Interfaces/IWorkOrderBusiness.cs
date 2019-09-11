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
        IEnumerable<WorkOrderReportRow> GetReport(int clientId, string statusCode);
        int Create(WorkOrder model);
        void UpdateStatus(int id, string statusCode);
        WorkOrder Get(int id);
        void MarkAsChecked(int id, string sampleCode);
    }
}
