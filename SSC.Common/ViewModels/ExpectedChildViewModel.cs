using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ExpectedChildViewModel
    {
        public string ParentBarcode { get; set; }
        public int? ExpectedChildQuantity { get; set; }
        public decimal? DilutionFactor { get; set; }
        public decimal? ResultingVolume { get; set; }
        public string UnitOfMeasureCode { get; set; }
    }
}
