using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISampleFunctionData
    {
        IEnumerable<SampleFunction> GetAll();
        SampleFunction Get(int id);
        void Create(SampleFunction model);
        void Update(SampleFunction model);
        void UpdatedIsEnabled(SampleFunction model, bool isEnabled);
        bool IsUniqueForClient(string code, int clientId, int? currentId);
    }
}
