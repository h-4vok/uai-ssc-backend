using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class SampleFunctionData : ISampleFunctionData
    {
        public SampleFunctionData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
            this.auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
        }

        private IAuthenticationProvider auth;
        private IUnitOfWork uow;

        private SampleFunction Fetch(IDataReader reader)
        {
            var record = new SampleFunction
            {
                Id = reader.GetInt32("Id"),
                Code = ReversibleEncryption.DecryptString(reader.GetString("Code"), auth.CurrentClientApiKey),
                Name = ReversibleEncryption.DecryptString(reader.GetString("Name"), auth.CurrentClientApiKey),
                Client = new ClientCompany
                {
                    Id = reader.GetInt32("ClientCompanyId"),
                    Name = reader.GetString("ClientCompanyName")
                },
                IsEnabled = reader.GetBoolean("IsEnabled")
            };

            return record;
        }

        public IEnumerable<SampleFunction> GetAll()
        {
            var tenantId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            return this.uow.GetDirect("sp_SampleFunction_getAll", this.Fetch, ParametersBuilder.With("TenantId", tenantId));
        }

        public SampleFunction Get(int id)
        {
            var tenantId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            return this.uow.GetOneDirect("sp_SampleFunction_get", this.Fetch,
                ParametersBuilder.With("TenantId", tenantId)
                    .And("Id", id)
            );
        }

        public void Create(SampleFunction model)
        {
            this.uow.NonQueryDirect("sp_SampleFunction_create",
                ParametersBuilder.With("TenantId", auth.CurrentClientId)
                    .And("Code", ReversibleEncryption.EncryptString(model.Code, auth.CurrentClientApiKey))
                    .And("Name", ReversibleEncryption.EncryptString(model.Name, auth.CurrentClientApiKey))
                    .And("CreatedBy", auth.CurrentUserId)
            );
        }

        public void Update(SampleFunction model)
        {
            this.uow.NonQueryDirect("sp_SampleFunction_update",
                ParametersBuilder.With("TenantId", auth.CurrentClientId)
                    .And("Id", model.Id)
                    .And("Code", ReversibleEncryption.EncryptString(model.Code, auth.CurrentClientApiKey))
                    .And("Name", ReversibleEncryption.EncryptString(model.Name, auth.CurrentClientApiKey))
                    .And("UpdatedBy", auth.CurrentUserId)
            );
        }

        public void UpdatedIsEnabled(int id, bool isEnabled)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_SampleFunction_update_isEnabled",
                ParametersBuilder.With("TenantId", auth.CurrentClientId)
                    .And("Id", id)
                    .And("IsEnabled", isEnabled)
            );
        }

        public bool IsUniqueForClient(string code, int clientId, int? currentId)
        {
            var tenantId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            return this.uow.ScalarDirect("sp_SampleFunction_exists",
                ParametersBuilder.With("TenantId", tenantId)
                    .And("Code", ReversibleEncryption.EncryptString(code, auth.CurrentClientApiKey))
                    .And("CurrentId", currentId)
                ).AsBool();
        }
    }
}
