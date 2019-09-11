using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISatelliteDataBusiness
    {
        IEnumerable<ParameterDataType> GetParameterDataTypes();
        IEnumerable<UnitOfMeasure> GetUnitOfMeasures();
        void Create<T>(T model);
        void UpdateIsEnabled<T>(int id, bool isEnabled);
        T Get<T>(int id);
        IEnumerable<PatientType> GetPatientTypes();
        IEnumerable<SampleBatchOrigin> GetSampleBatchOrigins();
    }
}
