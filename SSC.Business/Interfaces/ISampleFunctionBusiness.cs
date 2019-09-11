using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISampleFunctionBusiness
    {
        IEnumerable<SampleFunction> GetAll();
        SampleFunction Get(int id);
        void Create(SampleFunction model);
        void Update(SampleFunction model);
        void UpdateIsEnabled(int id, bool isEnabled);
    }
}
