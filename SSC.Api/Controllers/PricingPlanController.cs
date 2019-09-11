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

        public ResponseViewModel<IEnumerable<PricingPlan>> GetAll() => throw new NotImplementedException();
    }
}