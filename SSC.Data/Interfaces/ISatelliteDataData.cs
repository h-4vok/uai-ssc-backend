using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISatelliteDataData
    {
        IEnumerable<ParameterDataType> GetParameterDataTypes();
        IEnumerable<UnitOfMeasure> GetUnitOfMeasures();
        void Create<T>(T model);
        void CreateUnitOfMeasure(UnitOfMeasure model);
        void UpdateIsEnabled<T>(int id, bool isEnabled);
        void IsCodeUnique<T>(string code);
        T Get<T>(int id);
        IEnumerable<PatientType> GetPatientTypes();
        IEnumerable<SampleBatchOrigin> GetSampleBatchOrigins();
    }
}
