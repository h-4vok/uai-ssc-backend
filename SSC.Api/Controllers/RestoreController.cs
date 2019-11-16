using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class RestoreController : ApiController
    {
        

        public RestoreController(IBackupBusiness business) => this.business = business;

        protected IBackupBusiness business;

        public ResponseViewModel Post()
        {
            var request = HttpContext.Current.Request;
            var dir = ConfigurationManager.AppSettings["Backup.Path"];
            Directory.CreateDirectory(dir);
            var filename = String.Format("{0}.bkp", Guid.NewGuid().ToString());
            var filepath = Path.Combine(dir, filename);

            using (var fs = new FileStream(filepath, FileMode.Create))
            {
                request.InputStream.CopyTo(fs);
            }

            // call business
            var backup = new BackupRegistry
            {
                FilePath = filepath
            };

            try
            {
                this.business.DoRestoreFrom(backup);
            }
            catch
            {
                var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
                return i10n["restore.invalid-file"];
            }
            
            return true;
        }
    }
}