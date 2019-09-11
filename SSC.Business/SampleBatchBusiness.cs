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
    public class SampleBatchBusiness : ISampleBatchBusiness
    {
        public SampleBatchBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISampleBatchData>();
        }
        private ISampleBatchData data;

        public void Create(SampleBatch model)
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

        public void Update(SampleBatch model)
        {
            throw new NotImplementedException();
        }
    }
}
