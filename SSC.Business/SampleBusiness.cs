using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SampleBusiness : ISampleBusiness
    {
        public SampleBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISampleData>();
        }
        private ISampleData data;

        public IEnumerable<SampleReportRow> GetAvailableSamples(string functionCode, string typeCode)
        {
            var clientId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            return this.data.GetSamples(clientId, "available", null, null);
        }
    }
}
