using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.Logging;
using SSC.Data.Interfaces;
using SSC.Models;
using SSC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class LogData : ILogData
    {
        public LogData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private Log Fetch(IDataReader reader)
        {
            var type = (AuditRecordEnum)reader.GetInt32("AuditTypeId");

            Log record = type == AuditRecordEnum.Information ? (Log)new InfoLog() : (Log)new ErrorLog();

            record.Id = reader.GetInt32("Id");
            record.LoggedDate = reader.GetDateTime("CreatedDate");
            record.UserReference = reader.GetString("UserReference");
            record.ClientId = reader.GetInt32Nullable("ClientId") ?? 0;
            record.EventType = new EventType
            {
                Id = (int)type,
                Description = reader.GetString("AuditTypeDescription")
            };
            record.Message = reader.GetString("Message");

            return record;
        }

        public IEnumerable<Log> GetAll()
        {
            return this.uow.GetDirect("sp_AuditRecord_getAll", this.Fetch);
        }

        public Log Get(int id)
        {
            return this.uow.GetOneDirect("sp_AuditRecord_get", this.Fetch, ParametersBuilder.With("Id", id));
        }

        public void Create(AuditRecord record)
        {
            var authProvider = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_AuditRecord_create",
                ParametersBuilder.With("UserReference", record.UserName)
                .And("Message", record.Message)
                .And("AuditTypeId", (int)record.RecordType)
                .And("ClientId", authProvider.CurrentClientId)
                .And("CreatedDate", record.CreatedDate)
            );
        }
    }
}
