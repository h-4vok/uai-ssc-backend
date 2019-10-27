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
            this.data.Create(model);
        }

        public void Delete(int id)
        {
            this.data.Delete(id);
        }

        public SampleTypeParameter Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<SampleTypeParameterReportRow> GetAll()
        {
            return this.data.GetAll();
        }

        public void Update(SampleTypeParameter model)
        {
            this.data.Update(model);
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            this.data.UpdateIsEnabled(id, isEnabled);
        }
    }
}
