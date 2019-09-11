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
    public class SampleParameterTypeBusiness : ISampleParameterTypeBusiness
    {
        public SampleParameterTypeBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISampleParameterTypeData>();
        }
        private ISampleParameterTypeData data;

        public void Create(SampleTypeParameter model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SampleTypeParameter Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleTypeParameterReportRow> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SampleTypeParameter model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
