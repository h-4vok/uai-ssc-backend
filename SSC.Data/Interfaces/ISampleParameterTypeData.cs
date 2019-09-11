using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISampleParameterTypeData
    {
        IEnumerable<SampleTypeParameterReportRow> GetAll();
        SampleTypeParameter Get(int id);
        void Create(SampleTypeParameter model);
        void Update(SampleTypeParameter model);
        void Delete(int id);
        void UpdateIsEnabled(int id, bool isEnabled);
        bool Exists(string code, int? currentId);
        bool AnySampleIsAffected(int id, decimal? newMinimum, decimal? newMaximum);
    }
}
