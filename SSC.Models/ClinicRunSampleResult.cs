using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClinicRunSampleResult
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public decimal Volume { get; set; }
        public bool IsTrashed { get; set; }
    }
}
