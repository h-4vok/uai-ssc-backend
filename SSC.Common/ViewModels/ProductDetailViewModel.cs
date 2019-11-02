using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ProductDetailViewModel
    {
        public PricingPlan PricingPlan { get; set; }
        public decimal AverageRating { get; set; }
        public IEnumerable<PricingPlanComment> Comments { get; set; }
    }
}
