using SSC.Models;
using SSC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Logging
{
    public abstract class LoggerSubscriber
    {
        public abstract void Notify(AuditRecord record);

        public virtual void NotifyInformation(string userName, string message)
        {
            this.Notify(new AuditRecord
            {
                UserName = userName,
                Message = message,
                RecordType = AuditRecordEnum.Information
            });
        }

        public virtual void NotifyError(string userName, string message)
        {
            this.Notify(new AuditRecord
            {
                UserName = userName,
                Message = message,
                RecordType = AuditRecordEnum.Error
            });
        }
    }
}
