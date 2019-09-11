using DBNostalgia;
using SSC.Common;
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
            throw new NotImplementedException();
        }

        private ParameterDataType FetchParameterDataType(IDataReader reader)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<UnitOfMeasure> GetUnitOfMeasures()
        {
            throw new NotImplementedException();
        }

        public void Create<T>(T model)
        {
            throw new NotImplementedException();
        }

        public void CreateUnitOfMeasure(UnitOfMeasure model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled<T>(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public void IsCodeUnique<T>(string code)
        {
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
