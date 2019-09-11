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
    public class SampleTransactionData : ISampleTransactionData
    {
        public SampleTransactionData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private SampleTransactionReportRow FetchReportRow(IDataReader reader) => throw new NotImplementedException();

        private SampleTransaction Fetch(IDataReader reader) => throw new NotImplementedException();

        public void Create(SampleTransaction model)
        {
            throw new NotImplementedException();
        }

        public SampleTransaction Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleTransaction> GetReport(int sampleId)
        {
            throw new NotImplementedException();
        }
    }
}
