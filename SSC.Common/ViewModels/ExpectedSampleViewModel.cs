using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ExpectedSampleViewModel
    {
        public string ParentBarcode { get; set; }
        public string ChildBarcode { get; set; }
        public int ParentSampleId { get; set; }
        public decimal DilutionFactor { get; set; }
        public decimal VolumeToUse { get; set; }
        public decimal ResultingVolume { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public decimal? UsedParentVolume { get; set; }
        public decimal? FinalChildVolume { get; set; }
    }
}
