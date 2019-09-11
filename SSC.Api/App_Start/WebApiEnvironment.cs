using SSC.Common;
using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SSC.Api.App_Start
{
    public class WebApiEnvironment : IEnvironment
    {
        public static void RegisterEnvironmentDependency()
        {
            DependencyResolver.Obj.Register<IEnvironment, WebApiEnvironment>();
        }

        public string GetAboutUsText()
        {
            throw new NotImplementedException();
        }

        public string GetInfoEmail()
        {
            throw new NotImplementedException();
        }

        public string GetInputPathForRun(int clientId, int runId)
        {
            throw new NotImplementedException();
        }

        public string GetLabScriptFileFormat()
        {
            throw new NotImplementedException();
        }

        public string GetLabScriptsPath(int clientId)
        {
            throw new NotImplementedException();
        }

        public string GetLabScriptUserConnectionString()
        {
            throw new NotImplementedException();
        }

        public string GetMasterConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["master"].ConnectionString;
        }

        public string GetOutputPathForRun(int clientId, int runId)
        {
            throw new NotImplementedException();
        }

        public string GetPrimaryConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ssc"].ConnectionString;
        }
    }
}