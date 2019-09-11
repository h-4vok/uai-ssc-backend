using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IClinicRunBusiness
    {
        IEnumerable<ClinicRunReportRow> GetReport(int clientId);
        void Create(ClinicRun model);
        void UpdateStatus(int id, string statusCode);
        IEnumerable<RawDataReportRow> GetRawData(int id);
        void RegisterExecution(int id, IEnumerable<ClinicRunSampleResult> results);
        void Create(ClinicRunExecution model);
        IEnumerable<ClinicRunInvalidation> GetInvalidations(int runId);
        void CreateInvalidation(ClinicRunInvalidation model);
        void DeleteInvalidation(int id);
        void ReturnOneStageBack(int id);
        void AddRunComment(int id, string comment, int userId);
    }
}
