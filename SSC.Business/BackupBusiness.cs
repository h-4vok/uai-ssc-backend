using SSC.Business.Interfaces;
using SSC.Common;
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
            this.data = DependencyResolver.Obj.Resolve<IBackupBusiness>();
        }
        private IBackupBusiness data;

        public void DoBackup()
        {
            throw new NotImplementedException();
        }

        public void DoRestore(int id)
        {
            throw new NotImplementedException();
        }
    }
}
