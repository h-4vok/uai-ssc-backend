using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface IEnvironment
    {
        string GetMasterConnectionString();
        string GetPrimaryConnectionString();
        string GetAboutUsText();
        string GetInfoEmail();
        string GetOutputPathForRun(int clientId, int runId);
        string GetInputPathForRun(int clientId, int runId);
        string GetLabScriptsPath(int clientId);
        string GetLabScriptUserConnectionString();
        string GetLabScriptFileFormat();
    }
}
