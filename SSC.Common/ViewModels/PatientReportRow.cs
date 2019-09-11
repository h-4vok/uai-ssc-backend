using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class PatientReportRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PatientTypeDescription { get; set; }
        public int QuantityOfAvailableSamples { get; set; }
        public int QuantityOfUsedSamples { get; set; }
        public int TotalOfSamples { get; set; }
    }
}
