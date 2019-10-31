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
    public class BackupBusiness : IBackupBusiness
    {
        public BackupBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IBackupData>();
        }
        private IBackupData data;

        public void DoBackup()
        {
            this.data.DoBackup();
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
    }
}
