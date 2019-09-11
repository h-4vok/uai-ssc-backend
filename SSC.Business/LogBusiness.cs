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
    public class LogBusiness : ILogBusiness
    {
        public LogBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ILogData>();
        }
        private ILogData data;

        public Log Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
