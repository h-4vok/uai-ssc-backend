using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class PricingPlanCommentBusiness : IPricingPlanCommentBusiness
    {
        public PricingPlanCommentBusiness(IPricingPlanCommentData data) => this.data = data;

        protected IPricingPlanCommentData data;

        public void Create(PricingPlanComment model)
        {
            this.data.Create(model);
        }

        public ProductDetailViewModel Get(string planCode)
        {
            return this.data.Get(planCode);
        }

        public string GetCurrentUserComment()
        {
            return this.data.GetCurrentUserComment();
        }
    }
}
