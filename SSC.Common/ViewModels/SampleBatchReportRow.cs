using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class SampleBatchReportRow
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string BatchOriginDescription { get; set; }
        public string OriginInfo { get; set; }
        public int QuantityOfSamples { get; set; }
        public int QuantityOfChildSamples { get; set; }
        public int QuantityOfTotalSamples { get; set; }
        public int QuantityOfViableSamples { get; set; }
    }
}
