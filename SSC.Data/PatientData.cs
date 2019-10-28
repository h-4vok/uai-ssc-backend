using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
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
    public class PatientData : IPatientData
    {
        public PatientData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private PatientReportRow FetchReportRow(IDataReader reader)
        {
            var record = new PatientReportRow
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                PatientTypeDescription = reader.GetString("PatientTypeDescription"),
                QuantityOfAvailableSamples = reader.GetInt32("QuantityOfAvailableSamples"),
                QuantityOfUsedSamples = reader.GetInt32("QuantityOfUsedSamples"),
                TotalOfSamples = reader.GetInt32("QuantityOfAvailableSamples") + reader.GetInt32("QuantityOfUsedSamples")
            };

            return record;
        }

        private Patient Fetch(IDataReader reader)
        {
            var record = new Patient
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                PatientType = new PatientType
                {
                    Id = reader.GetInt32("PatientTypeId"),
                    Code = reader.GetString("PatientTypeCode"),
                    Description = reader.GetString("PatienTypeDescription")
                },
                Tenant = new ClientCompany
                {
                    Id = reader.GetInt32("ClientCompanyId"),
                    Name = reader.GetString("ClientCompanyName")
                }
            };

            return record;
        }

        public void Create(Patient model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_Patient_create",
                ParametersBuilder.With("PatientTypeId", model.PatientType.Id)
                    .And("Name", model.Name)
                    .And("TenantId", model.Tenant.Id)
                    .And("CreatedBy", auth.CurrentUserId)
            );
        }

        public void Delete(int id)
        {
            this.uow.NonQueryDirect("sp_Patient_delete", ParametersBuilder.With("Id", id));
        }

        public Patient Get(int id)
        {
            return this.uow.GetOneDirect("sp_Patient_get", this.Fetch, ParametersBuilder.With("Id", id));
        }

        public IEnumerable<PatientReportRow> GetAll(int clientId)
        {
            return this.uow.GetDirect("sp_Patient_getAll", this.FetchReportRow, ParametersBuilder.With("TenantId", clientId));
        }

        public bool IsOwnedByClient(int id, int clientId)
        {
            return this.uow.ScalarDirect("sp_Patient_isOwnedByClient", ParametersBuilder.With("Id", id).And("TenantId", clientId)).AsBool();
        }

        public void Update(Patient model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_Patient_update",
                ParametersBuilder.With("PatientTypeId", model.PatientType.Id)
                    .And("Name", model.Name)
                    .And("TenantId", model.Tenant.Id)
                    .And("Id", model.Id)
                    .And("UpdatedBy", auth.CurrentUserId)
            );
        }
    }
}
