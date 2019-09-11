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
        IEnumerable<WorkOrderReportRow> GetReport(int clientId, string statusCode);
        int Create(WorkOrder model);
        void UpdateStatus(int id, string statusCode);
        WorkOrder Get(int id);
        void AssignTo(int id, int userId);
        void MarkAsChecked(int id, string sampleCode);
    }
}
