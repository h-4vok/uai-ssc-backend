using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class PricingPlanBusiness : IPricingPlanBusiness
    {
        public PricingPlanBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IPricingPlanData>();
        }

        public IPricingPlanData data;

        public IEnumerable<PricingPlan> GetAll(string nameAlike, int minPrice, int maxPrice, int minRating)
        {
            return this.data.GetAll(nameAlike, minPrice, maxPrice, minRating);
        }

        public PricingPlan GetByCode(string code)
        {
            return this.data.GetByCode(code);
        }
    }
}
