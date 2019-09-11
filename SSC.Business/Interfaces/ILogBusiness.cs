﻿using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ILogBusiness
    {
        IEnumerable<Log> GetAll();
        Log Get(int id);
    }
}
