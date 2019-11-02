using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IPricingPlanCommentData
    {
        ProductDetailViewModel Get(string planCode);
        void Create(PricingPlanComment model);
        string GetCurrentUserComment();
    }
}
