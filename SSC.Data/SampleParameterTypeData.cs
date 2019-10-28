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
    public class SampleParameterTypeData : ISampleParameterTypeData
    {
        public SampleParameterTypeData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        public bool AnySampleIsAffected(int id, decimal? newMinimum, decimal? newMaximum)
        {
            throw new NotImplementedException();
        }

        public void Create(SampleTypeParameter model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_SampleTypeParameter_create",
                ParametersBuilder.With("Code", model.Code)
                    .And("DefaultDescription", model.DefaultDescription)
                    .And("ParameterDataTypeId", model.DataType.Id)
                    .And("DecimalDigits", model.DecimalDigits)
                    .And("MinimumRange", model.MinimumRange)
                    .And("MaximumRange", model.MaximumRange)
                    .And("UnitOfMeasureId", model.UnitOfMeasure.Id)
                    .And("CreatedBy", auth.CurrentUserId)
            );
        }

        public void Delete(int id)
        {
            this.uow.NonQueryDirect("sp_SampleTypeParameter_delete", ParametersBuilder.With("Id", id));
        }

        public bool Exists(string code, int? currentId)
        {
            return this.uow.ScalarDirect("sp_SampleTypeParameter_exists",
                ParametersBuilder.With("Code", code)
                    .And("CurrentId", currentId)
            ).AsBool();
        }

        public SampleTypeParameter Get(int id)
        {
            return this.uow.GetOneDirect("sp_SampleTypeParameter_get", this.Fetch, ParametersBuilder.With("Id", id));
        }

        public IEnumerable<SampleTypeParameterReportRow> GetAll()
        {
            return this.uow.GetDirect("sp_SampleTypeParameter_getAll", this.FetchReportRow);
        }

        public void Update(SampleTypeParameter model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_SampleTypeParameter_update",
                ParametersBuilder.With("Id", model.Id)
                    .And("Code", model.Code)
                    .And("ParameterDataTypeId", model.DataType.Id)
                    .And("DecimalDigits", model.DecimalDigits)
                    .And("MinimumRange", model.MinimumRange)
                    .And("MaximumRange", model.MaximumRange)
                    .And("UnitOfMeasureId", model.UnitOfMeasure.Id)
                    .And("UpdatedBy", auth.CurrentUserId)
            );
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            this.uow.NonQueryDirect("sp_SampleParameterType_update_isEnabled",
                ParametersBuilder.With("Id", id)
                    .And("IsEnabled", isEnabled)
            );
        }

        private SampleTypeParameter Fetch(IDataReader reader)
        {
            var record = new SampleTypeParameter
            {
                Id = reader.GetInt32("Id"),
                Code = reader.GetString("Code"),
                DefaultDescription = reader.GetString("DefaultDescription"),
                DataType = new ParameterDataType
                {
                    Id = reader.GetInt32("ParameterDataTypeId"),
                    Code = reader.GetString("ParameterDataTypeCode")
                },
                DecimalDigits = reader.GetInt32Nullable("DecimalDigits"),
                MinimumRange = Convert.ToInt32(reader.GetValue("MinimumRange")),
                MaximumRange = Convert.ToInt32(reader.GetValue("MaximumRange")),
                UnitOfMeasure = new UnitOfMeasure
                {
                    Id = reader.GetInt32("UnitOfMeasureId"),
                    Code = reader.GetString("UnitOfMeasureCode")
                },
                IsEnabled = reader.GetBoolean("IsEnabled")
            };

            return record;
        }

        private SampleTypeParameterReportRow FetchReportRow(IDataReader reader)
        {
            var record = new SampleTypeParameterReportRow
            {
                Id = reader.GetInt32("Id"),
                Code = reader.GetString("Code"),
                Description = reader.GetString("Description"),
                DataTypeName = reader.GetString("DataTypeName"),
                MinimumRange = Convert.ToInt32(reader.GetValue("MinimumRange")),
                MaximumRange = Convert.ToInt32(reader.GetValue("MaximumRange")),
                DecimalDigits = reader.GetInt32Nullable("DecimalDigits"),
                UpdatedDate = reader.GetDateTime("UpdatedDate"),
                UpdatedBy = reader.GetString("UpdatedBy"),
                IsEnabled = reader.GetBoolean("IsEnabled")
            };

            return record;
        }
    }
}
