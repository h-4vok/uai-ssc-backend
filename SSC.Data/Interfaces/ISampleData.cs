using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISampleData
    {
        IEnumerable<SampleReportRow> GetSamples(int clientId, string statusCode);
        IEnumerable<CheckableSampleReportRow> GetParentSamplesOfWorkOrder(int workOrderId);
    }
}
