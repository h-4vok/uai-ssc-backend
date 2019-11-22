using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IBackupBusiness
    {
        void DoBackup(string filepath, bool isPathOnly);
        void DoRestore(int id);
        void DoRestoreFrom(BackupRegistry model);
        BackupRegistry Get(int id);
        IEnumerable<BackupRegistry> GetAll();
    }
}
