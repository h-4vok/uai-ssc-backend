using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISampleTypeData
    {
        IEnumerable<SampleTypeReportRow> GetAll(int clientId);
        SampleType Get(int id);
        int Create(SampleType model);
        void Update(SampleType model);
        void Delete(int id);
        bool IsUsedOnSamples(int id);
    }
}
