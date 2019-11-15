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
        void DoBackup(string filepath);
        void DoRestore(int id);
        BackupRegistry Get(int id);
        IEnumerable<BackupRegistry> GetAll();
    }
}
