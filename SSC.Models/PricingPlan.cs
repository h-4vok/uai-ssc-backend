using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class PricingPlan
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? UserLimit { get; set; }
        public int? ClinicRehearsalLimit { get; set; }
        public int? PatientSampleLimit { get; set; }
        public int? ControlSampleLimit { get; set; }
        public int? AnualDiscountPercentage { get; set; }
        public decimal Price { get; set; }
    }
}
