using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class BackupBusiness : IBackupBusiness
    {
        public BackupBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IBackupData>();
        }
        private IBackupData data;

        public void DoBackup(string filepath, bool isPathOnly)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<string>.Start(filepath)
                .MandatoryString(x => x, i10n["backup.filepath"])
                .FailWhenClosureReturnsFalse(x =>
                {
                    if (isPathOnly)
                    {
                        filepath = Path.Combine(x, String.Format("{0}.bkp", Guid.NewGuid()));
                    }

                    return true;
                }, "")
                .FailWhenClosureReturnsFalse(x => isPathOnly || x.ToLowerInvariant().EndsWith(".bkp"), i10n["backup.file-must-end-with-bkp"])
                .FailWhenClosureReturnsFalse(x => Directory.Exists(Path.GetDirectoryName(x)), i10n["backup.dir-not-exists"])
                .FailWhenClosureReturnsFalse(x => isPathOnly || File.Exists(x) == false, i10n["backup.file-exists"])
                .ThrowExceptionIfApplicable();

            this.data.DoBackup(filepath);
        }

        public void DoRestore(int id)
        {
            this.data.DoRestore(id);
        }

        public BackupRegistry Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<BackupRegistry> GetAll()
        {
            return this.data.GetAll();
        }

        public void DoRestoreFrom(BackupRegistry model)
        {
            this.data.DoRestoreFrom(model);
        }
    }
}
