using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IClientCompanyLabScriptBusiness
    {
        void SaveScript(int clientId, byte[] data, string filename);
        ClientCompanyLabScript GetScript(string id);
        IEnumerable<ClientCompanyLabScript> GetScripts(int clientId);
    }
}
