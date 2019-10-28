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
    public class SatelliteDataData : ISatelliteDataData
    {
        public SatelliteDataData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private UnitOfMeasure FetchUnitOfMeasure(IDataReader reader)
        {
            var record = new UnitOfMeasure
            {
                Id = reader.GetInt32("Id"),
                Code = reader.GetString("Code"),
                DefaultDescription = reader.GetString("DefaultDescription"),
                IsEnabled = reader.GetBoolean("IsEnabled")
            };

            return record;
        }

        private ParameterDataType FetchParameterDataType(IDataReader reader)
        {
            var record = new ParameterDataType
            {
                Id = reader.GetInt32("Id"),
                Code = reader.GetString("Code")
            };

            return record;
        }

        private PatientType FetchPatientType(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private SampleBatchOrigin FetchSampleBatchOrigin(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParameterDataType> GetParameterDataTypes()
        {
            return this.uow.GetDirect("sp_ParameterDataType_getAll", this.FetchParameterDataType);
        }

        public IEnumerable<UnitOfMeasure> GetUnitOfMeasures()
        {
            return this.uow.GetDirect("sp_UnitOfMeasure_getAll", this.FetchUnitOfMeasure);
        }

        public void Create<T>(T model)
        {
            if (typeof(T) == typeof(UnitOfMeasure))
            {
                this.CreateUnitOfMeasure(model as UnitOfMeasure);
            }
        }

        public void CreateUnitOfMeasure(UnitOfMeasure model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_UnitOfMeasure_create",
                ParametersBuilder.With("Code", model.Code)
                    .And("DefaultDescription", model.DefaultDescription)
                    .And("CreatedBy", auth.CurrentUserId)
            );
        }

        public void UpdateIsEnabled<T>(int id, bool isEnabled)
        {
            if (typeof(T) == typeof(UnitOfMeasure))
            {
                this.uow.NonQueryDirect("sp_UnitOfMeasure_update_isEnabled", ParametersBuilder.With("Id", id).And("IsEnabled", isEnabled));
            }
        }

        public bool IsCodeUnique<T>(string code)
        {
            if (typeof(T) == typeof(UnitOfMeasure))
            {
                return this.uow.ScalarDirect("sp_UnitOfMeasure_exists", ParametersBuilder.With("Code", code)).AsBool();
            }

            throw new NotImplementedException();
        }

        public T Get<T>(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientType> GetPatientTypes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleBatchOrigin> GetSampleBatchOrigins()
        {
            throw new NotImplementedException();
        }
    }
}
