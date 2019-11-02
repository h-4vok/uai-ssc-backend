using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IPricingPlanCommentBusiness
    {
        void Create(PricingPlanComment model);
        ProductDetailViewModel Get(string planCode);
        string GetCurrentUserComment();
    }
}
