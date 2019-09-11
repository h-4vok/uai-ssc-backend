using DBNostalgia;
using SSC.Common;
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
    public class SampleFunctionData : ISampleFunctionData
    {
        public SampleFunctionData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private SampleFunction Fetch(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleFunction> GetAll()
        {
            throw new NotImplementedException();
        }

        public SampleFunction Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(SampleFunction model)
        {
            throw new NotImplementedException();
        }

        public void Update(SampleFunction model)
        {
            throw new NotImplementedException();
        }

        public void UpdatedIsEnabled(SampleFunction model, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueForClient(string code, int clientId, int? currentId)
        {
            throw new NotImplementedException();
        }
    }
}
