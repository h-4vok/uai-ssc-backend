using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IPricingPlanBusiness
    {
        IEnumerable<PricingPlan> GetAll();
        PricingPlan GetByCode(string code);
    }
}
