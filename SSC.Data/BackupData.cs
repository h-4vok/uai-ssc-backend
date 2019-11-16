using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SSC.Data
{
    public class BackupData : IBackupData
    {
        public BackupData()
        {
            IDbConnection connectionBuilder()
            {
                var environment = DependencyResolver.Obj.Resolve<IEnvironment>();
                var connection = new SqlConnection(environment.GetMasterConnectionString());
                return connection;
            }

            this.uow = new UnitOfWork(connectionBuilder);
        }

        private readonly IUnitOfWork uow;

        public void DoBackup(string filepath)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var environment = DependencyResolver.Obj.Resolve<IEnvironment>();

            //var backupPath = environment.GetBackupPath();
            //Directory.CreateDirectory(backupPath);

            //var filename = String.Format("SSC_{0}.bkp", DateTime.Now.ToString("yyyyMMdd_hhmmss"));
            //var filepath = Path.Combine(backupPath, filename);

            this.uow.NonQueryDirect("Backup_perform", ParametersBuilder.With("filepath", filepath));
            this.uow.NonQueryDirect("Backup_new", ParametersBuilder.With("filepath", filepath).And("CreatedBy", auth.CurrentUserName));
        }

        protected BackupRegistry Fetch(IDataReader reader)
        {
            var item = new BackupRegistry
            {
                Id = reader.GetInt32("Id"),
                FilePath = reader.GetString("FilePath"),
                BackupDate = reader.GetDateTime("BackupDate"),
                CreatedBy = reader.GetString("CreatedBy")
            };

            return item;
        }

        public void DoRestore(int id)
        {
            var model = this.Get(id);

            this.DoRestoreFrom(model);
        }

        public BackupRegistry Get(int id)
        {
            return this.uow.GetOneDirect("Backup_getOne", this.Fetch, ParametersBuilder.With("id", id));
        }

        public IEnumerable<BackupRegistry> GetAll()
        {
            return this.uow.GetDirect("Backup_get", this.Fetch);
        }

        public void DoRestoreFrom(BackupRegistry model)
        {
            this.uow.NonQueryDirect("Backup_restore", ParametersBuilder.With("filepath", model.FilePath).And("dbname", "SSC.Database"));
        }
    }
}
