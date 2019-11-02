using SSC.Api.Behavior;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class PricingPlanCommentController : ApiController
    {
        public class PostPricingPlanCommentViewModel
        {
            public int Rating { get; set; }
            public string Comment { get; set; }
        }

        public PricingPlanCommentController(IPricingPlanCommentBusiness business) => this.business = business;

        protected IPricingPlanCommentBusiness business;

        [SscAuthorize]
        public ResponseViewModel Post(PostPricingPlanCommentViewModel viewModel)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var model = new PricingPlanComment
            {
                CreatedBy = auth.CurrentUserId,
                Comment = viewModel.Comment,
                Rating = viewModel.Rating,
                CommentBy = auth.CurrentUserName,
            };

            return ResponseViewModel.RunAndReturn(() => this.business.Create(model));
        }

        public ResponseViewModel<ProductDetailViewModel> Get(string planCode) => this.business.Get(planCode);

        [SscAuthorize]
        public ResponseViewModel<string> Get(int id) => new ResponseViewModel<string> { Result = this.business.GetCurrentUserComment() };
    }
}