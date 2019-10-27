using SSC.Business.Interfaces;
using SSC.Common;
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
            throw new NotImplementedException();
        }

        public T Get<T>(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParameterDataType> GetParameterDataTypes()
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

        public IEnumerable<UnitOfMeasure> GetUnitOfMeasures()
        {
            return this.data.GetUnitOfMeasures();
        }

        public void UpdateIsEnabled<T>(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
