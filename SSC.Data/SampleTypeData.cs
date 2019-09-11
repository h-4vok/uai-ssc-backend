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
    public class SampleTypeData : ISampleTypeData
    {
        public SampleTypeData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private SampleTypeReportRow FetchReportRow(IDataReader reader) => throw new NotImplementedException();

        public int Create(SampleType model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SampleType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleTypeReportRow> GetAll(int clientId)
        {
            throw new NotImplementedException();
        }

        public bool IsUsedOnSamples(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SampleType model)
        {
            throw new NotImplementedException();
        }
    }
}
