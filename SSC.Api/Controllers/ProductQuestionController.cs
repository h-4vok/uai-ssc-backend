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
    public class ProductQuestionController : ApiController
    {
        public ProductQuestionController(IProductQuestionBusiness business) => this.business = business;

        protected IProductQuestionBusiness business;

        public ResponseViewModel Post(ProductQuestion model) => ResponseViewModel.RunAndReturn(() => this.business.Post(model));
        public ResponseViewModel Put(int id, ProductQuestion model) => ResponseViewModel.RunAndReturn(() => this.business.Reply(model));
        public ResponseViewModel<IEnumerable<ProductQuestion>> Get(string pricingPlanCode = null)
        {
            if (!String.IsNullOrWhiteSpace(pricingPlanCode))
            {
                return this.business.GetForProduct(pricingPlanCode).ToList();
            }
            else
            {
                return this.business.GetAll().ToList();
            }
        }

        public ResponseViewModel<ProductQuestion> Get(int id) => this.business.Get(id);
    }
}