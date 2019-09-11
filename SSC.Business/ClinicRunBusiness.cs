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
    public class ClinicRunBusiness : IClinicRunBusiness
    {
        public ClinicRunBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IClinicRunData>();
        }
        private IClinicRunData data;

        public void AddRunComment(int id, string comment, int userId)
        {
            throw new NotImplementedException();
        }

        public void Create(ClinicRun model)
        {
            throw new NotImplementedException();
        }

        public void Create(ClinicRunExecution model)
        {
            throw new NotImplementedException();
        }

        public void CreateInvalidation(ClinicRunInvalidation model)
        {
            throw new NotImplementedException();
        }

        public void DeleteInvalidation(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClinicRunInvalidation> GetInvalidations(int runId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RawDataReportRow> GetRawData(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClinicRunReportRow> GetReport(int clientId)
        {
            throw new NotImplementedException();
        }

        public void RegisterExecution(int id, IEnumerable<ClinicRunSampleResult> results)
        {
            throw new NotImplementedException();
        }

        public void ReturnOneStageBack(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int id, string statusCode)
        {
            throw new NotImplementedException();
        }
    }
}
