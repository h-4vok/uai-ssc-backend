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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string code, int? currentId)
        {
            throw new NotImplementedException();
        }

        public SampleTypeParameter Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleTypeParameterReportRow> GetAll()
        {
            var clientId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;
            return this.uow.GetDirect("sp_SampleTypeParameter_getAll", this.FetchReportRow, ParametersBuilder.With("TenantId", clientId));
        }

        public void Update(SampleTypeParameter model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        private SampleTypeParameterReportRow FetchReportRow(IDataReader reader)
        {
            var record = new SampleTypeParameterReportRow
            {
                Id = reader.GetInt32("Id"),
                Code = reader.GetString("Code"),
                Description = reader.GetString("Description"),
                DataTypeName = reader.GetString("DataTypeName"),
                MinimumRange = reader.GetInt32Nullable("MinimumRange"),
                MaximumRange = reader.GetInt32Nullable("MaximumRange"),
                DecimalDigits = reader.GetInt32Nullable("DecimalDigits"),
                UpdatedDate = reader.GetDateTime("UpdatedDate"),
                UpdatedBy = reader.GetString("UpdatedBy"),
                IsEnabled = reader.GetBoolean("IsEnabled")
            };

            return record;
        }
    }
}
