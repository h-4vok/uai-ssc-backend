using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Logging;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class LogBusiness : LoggerSubscriber, ILogBusiness
    {
        public LogBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ILogData>();
        }
        private ILogData data;

        public Log Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<Log> GetAll()
        {
            return this.data.GetAll();
        }

        public override void Notify(AuditRecord record)
        {
            this.data.Create(record);
        }
    }
}
