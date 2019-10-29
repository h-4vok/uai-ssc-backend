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
    public class SampleTypeData : ISampleTypeData
    {
        public SampleTypeData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private readonly IUnitOfWork uow;

        private SampleTypeReportRow FetchReportRow(IDataReader reader)
        {
            var record = new SampleTypeReportRow
            {
                Name = reader.GetString("Name"),
                UpdatedBy = reader.GetString("UpdatedBy"),
                UpdatedDate = reader.GetDateTime("UpdatedDate"),
                SampleTypeId = reader.GetInt32("SampleTypeId")
            };

            return record;
        }

        private SampleType Fetch(IDataReader reader)
        {
            var record = new SampleType
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name")
            };

            return record;
        }

        public void Create(SampleType model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.Run(() =>
            {
                model.Id = this.uow.Scalar("sp_SampleType_create",
                    ParametersBuilder.With("Name", model.Name)
                        .And("TenantId", auth.CurrentClientId)
                        .And("CreatedBy", auth.CurrentUserId)
                ).AsInt();

                model.Parameters.ForEach(item =>
                {
                    this.uow.NonQuery("sp_SampleType_addParameter",
                        ParametersBuilder.With("Id", model.Id)
                        .And("SampleTypeParameterId", item.Id)
                        .And("CreatedBy", auth.CurrentUserId)
                    );
                });

            }, true);
        }

        public void Delete(int id)
        {
            this.uow.NonQueryDirect("sp_SampleType_delete", ParametersBuilder.With("Id", id));
        }

        public SampleType Get(int id)
        {
            var model = this.uow.GetOneDirect("sp_SampleType_get", this.Fetch, ParametersBuilder.With("Id", id));

            var parameterData = DependencyResolver.Obj.Resolve<ISampleParameterTypeData>();

            model.Parameters = parameterData.GetForSampleType(model.Id);

            return model;
        }

        public IEnumerable<SampleTypeReportRow> GetAll(int clientId)
        {
            var tenantId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            return this.uow.GetDirect("sp_SampleType_getAll", this.FetchReportRow, ParametersBuilder.With("TenantId", tenantId));
        }

        public bool IsUsedOnSamples(int id)
        {
            return this.uow.ScalarDirect("sp_SampleType_usedOnSamples", ParametersBuilder.With("Id", id)).AsBool();
        }

        public void Update(SampleType model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.Run(() =>
            {
                this.uow.Scalar("sp_SampleType_update",
                    ParametersBuilder.With("Name", model.Name)
                        .And("TenantId", auth.CurrentClientId)
                        .And("UpdatedBy", auth.CurrentUserId)
                        .And("Id", model.Id)
                ).AsInt();

                this.uow.NonQuery("sp_SampleType_deleteParameters", ParametersBuilder.With("Id", model.Id));

                model.Parameters.ForEach(item =>
                {
                    this.uow.NonQuery("sp_SampleType_addParameter",
                        ParametersBuilder.With("Id", model.Id)
                        .And("SampleTypeParameterId", item.Id)
                        .And("CreatedBy", auth.CurrentUserId)
                    );
                });

            }, true);
        }

        public bool Exists(string name, int? currentId = null)
        {
            return this.uow.ScalarDirect("sp_SampleType_exists",
                ParametersBuilder.With("Name", name)
                    .And("CurrentId", currentId)
            ).AsBool();
        }
    }
}
