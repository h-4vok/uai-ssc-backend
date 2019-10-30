using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class PricingPlanController : ApiController
    {
        private IPricingPlanBusiness business;

        public PricingPlanController(IPricingPlanBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<PricingPlan>> GetAll(string nameAlike = null, int minPrice = 0, int maxPrice = 50000, int minRating = 1) 
            => this.business.GetAll(nameAlike, minPrice, maxPrice, minRating).ToList();
    }
}