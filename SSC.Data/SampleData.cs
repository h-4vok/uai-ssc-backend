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
    public class SampleData : ISampleData
    {
        public SampleData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private SampleReportRow FetchReportRow(IDataReader reader) => throw new NotImplementedException();

        public IEnumerable<Sample> GetSamples(int clientId, string statusCode, string funcitonCode, string typeCode)
        {
            throw new NotImplementedException();
        }
    }
}
