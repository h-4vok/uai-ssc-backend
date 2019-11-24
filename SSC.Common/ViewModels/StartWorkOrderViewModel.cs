using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class StartWorkOrderViewModel
    {
        public IEnumerable<SampleReportRow> ParentSamples { get; set; }
        public IEnumerable<ExpectedChildViewModel> ExpectedChilds { get; set; }
    }
}
