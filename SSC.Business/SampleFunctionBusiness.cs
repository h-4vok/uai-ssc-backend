using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SampleFunctionBusiness : ISampleFunctionBusiness
    {
        public SampleFunctionBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISampleFunctionData>();
        }
        private ISampleFunctionData data;

        private bool IsForbiddenCode(string code) => throw new NotImplementedException();

        public void Create(SampleFunction model)
        {
            throw new NotImplementedException();
        }

        public SampleFunction Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleFunction> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SampleFunction model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
