using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class WorkOrderExpectedSample
    {
        public int Id { get; set; }
        public Sample ParentSample { get; set; }
        public decimal DilutionFactor { get; set; }
        public decimal VolumeToUse { get; set; }
        public decimal ResultingVolume { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
