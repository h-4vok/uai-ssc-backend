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
    public class ClientCompanyLabScriptData : IClientCompanyLabScriptData
    {
        public ClientCompanyLabScriptData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        public ClientCompanyLabScript Fetch(IDataReader reader) => throw new NotImplementedException();

        public void Create(ClientCompanyLabScript model)
        {
            throw new NotImplementedException();
        }

        public ClientCompanyLabScript Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientCompanyLabScript> GetAll(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
