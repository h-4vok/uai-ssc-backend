using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class SampleTypeParameterReportRow
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DataTypeName { get; set; }
        public decimal? MinimumRange { get; set; }
        public decimal? MaximumRange { get; set; }
        public int? DecimalDigits { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsEnabled { get; set; }
    }
}
