﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IBackupData
    {
        void DoBackup();
        void DoRestore(int id);
    }
}
