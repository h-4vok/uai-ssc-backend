using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISampleBatchBusiness
    {
        IEnumerable<SampleBatchReportRow> GetReport(int tenantId);
        IEnumerable<SampleReportRow> Get(int id);
        void Create(SampleBatch model);
        void Update(SampleBatch model);
    }
}
