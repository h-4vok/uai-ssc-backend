using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SampleTypeParameter
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DefaultDescription { get; set; }
        public ParameterDataType DataType { get; set; }
        public int? DecimalDigits { get; set; }
        public decimal? MinimumRange { get; set; }
        public decimal? MaximumRange { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public ClientCompany Tenant { get; set; }
    }
}
