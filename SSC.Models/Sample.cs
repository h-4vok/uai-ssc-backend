using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class Sample
    {
        public int Id { get; set; }
        public SampleType SampleType { get; set; }
        public SampleFunction SampleFunction { get; set; }
        public decimal InitialVolume { get; set; }
        public decimal CurrentVolume { get; set; }
        public IEnumerable<SampleParameter> Parameters { get; set; } = new List<SampleParameter>();
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public IEnumerable<SampleTransaction> Transactions { get; set; }
    }
}
