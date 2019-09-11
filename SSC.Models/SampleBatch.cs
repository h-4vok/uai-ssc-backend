using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SampleBatch
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public DateTime EntryDate { get; set; }
        public SampleBatchOrigin Origin { get; set; }
        public IEnumerable<Sample> Samples { get; set; }
        public ClientCompany Tenant { get; set; }
        public Patient Patient { get; set; }
    }
}
