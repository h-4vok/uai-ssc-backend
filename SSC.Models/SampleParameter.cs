using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SampleParameter
    {
        public int Id { get; set; }
        public SampleTypeParameter ParameterType { get; set; }
        public decimal Value { get; set; }
    }
}
