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
    public class ClientCompanyLabScriptBusiness : IClientCompanyLabScriptBusiness
    {
        public ClientCompanyLabScriptBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IClientCompanyLabScriptData>();
        }
        private IClientCompanyLabScriptData data;

        public string EncryptWithCurrentClientSalt(string data) => throw new NotImplementedException();

        public ClientCompanyLabScript GetScript(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientCompanyLabScript> GetScripts(int clientId)
        {
            throw new NotImplementedException();
        }

        public void SaveScript(int clientId, byte[] data, string filename)
        {
            throw new NotImplementedException();
        }
    }
}
