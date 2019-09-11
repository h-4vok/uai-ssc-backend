using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClinicRunInvalidation
    {
        public int Id { get; set; }
        public Sample Sample { get; set; }
        public string Comments { get; set; }
    }
}
