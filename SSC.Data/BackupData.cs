using DBNostalgia;
using SSC.Common;
using SSC.Data.Interfaces;
using System;

namespace SSC.Data
{
    public class BackupData : IBackupData
    {
        public BackupData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

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
