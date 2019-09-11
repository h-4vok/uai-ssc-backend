using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISampleTransactionBusiness
    {
        IEnumerable<SampleTransactionReportRow> GetReport(int sampleId);
        SampleTransaction Get(int id);
        void Create(SampleTransaction model);
    }
}
