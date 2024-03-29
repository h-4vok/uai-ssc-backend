﻿using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IBackupData
    {
        void DoBackup(string filepath);
        void DoRestore(int id);
        void DoRestoreFrom(BackupRegistry model);
        BackupRegistry Get(int id);
        IEnumerable<BackupRegistry> GetAll();
    }
}
