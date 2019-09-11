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
    public class SampleTransactionBusiness : ISampleTransactionBusiness
    {
        public SampleTransactionBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISampleTransactionData>();
        }
        private ISampleTransactionData data;

        public void Create(SampleTransaction model)
        {
            throw new NotImplementedException();
        }

        public SampleTransaction Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleTransactionReportRow> GetReport(int sampleId)
        {
            throw new NotImplementedException();
        }
    }
}
