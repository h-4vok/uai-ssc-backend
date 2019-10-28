using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SatelliteDataBusiness : ISatelliteDataBusiness
    {
        public SatelliteDataBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISatelliteDataData>();
        }
        private ISatelliteDataData data;

        public void Create<T>(T model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            if (typeof(T) == typeof(UnitOfMeasure))
            {
                var item = model as UnitOfMeasure;

                if (this.data.IsCodeUnique<UnitOfMeasure>(item.Code))
                {
                    throw new UnprocessableEntityException(i10n["unit-of-measure.validation.code-not-unique"]);
                }

                this.data.Create(item);
            }
        }

        public T Get<T>(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParameterDataType> GetParameterDataTypes()
        {
            return this.data.GetParameterDataTypes();
        }

        public IEnumerable<PatientType> GetPatientTypes()
        {
            return this.data.GetPatientTypes();
        }

        public IEnumerable<SampleBatchOrigin> GetSampleBatchOrigins()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UnitOfMeasure> GetUnitOfMeasures()
        {
            return this.data.GetUnitOfMeasures();
        }

        public void UpdateIsEnabled<T>(int id, bool isEnabled)
        {
            this.data.UpdateIsEnabled<T>(id, isEnabled);
        }
    }
}
