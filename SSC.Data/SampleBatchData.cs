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
    public class SampleBatchData : ISampleBatchData
    {
        public SampleBatchData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private SampleBatchReportRow FetchReportRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private SampleBatch Fetch(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private Sample FetchSample(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private SampleReportRow FetchSampleReportRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleReportRow> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleBatchReportRow> GetReport(int tenantId)
        {
            throw new NotImplementedException();
        }
    }
}
