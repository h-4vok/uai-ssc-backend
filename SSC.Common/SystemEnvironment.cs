using SSC.Common;
using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Hosting;
using System.IO;

namespace SSC.Common
{
    public class SystemEnvironment : IEnvironment
    {
        public string GetAboutUsText()
        {
            throw new NotImplementedException();
        }

        public string GetBackupPath()
        {
            return ConfigurationManager.AppSettings["Backup.Path"];
        }

        public string GetEmailTemplate(string filename)
        {
            var authProvider = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            var fullFileName = String.Format(filename, authProvider.CurrentLanguageCode);
            var fullPath = HostingEnvironment.MapPath(String.Format("~/EmailTemplates/{0}", fullFileName));
            var templateContent = File.ReadAllText(fullPath);

            return templateContent;
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