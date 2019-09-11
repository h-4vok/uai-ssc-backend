using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class RawDataReportRow
    {
        public string Barcode { get; set; }
        public decimal Vol { get; set; }
        public string Uom { get; set; }
        public string Fnc { get; set; }
    }
}
