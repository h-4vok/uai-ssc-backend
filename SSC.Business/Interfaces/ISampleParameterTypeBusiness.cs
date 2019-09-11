using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISampleParameterTypeBusiness
    {
        IEnumerable<SampleTypeParameterReportRow> GetAll();
        SampleTypeParameter Get(int id);
        void Create(SampleTypeParameter model);
        void Update(SampleTypeParameter model);
        void Delete(int id);
        void UpdateIsEnabled(int id, bool isEnabled);
    }
}
