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
    public class ClinicRunData : IClinicRunData
    {
        public ClinicRunData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private ClinicRunReportRow FetchReportRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private RawDataReportRow FetchRawDataRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private ClinicRunInvalidation FetchInvalidation(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void AddClinicRunComment(ClinicRunComment model)
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
