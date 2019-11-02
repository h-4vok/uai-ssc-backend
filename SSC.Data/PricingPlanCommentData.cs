using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class PricingPlanCommentData : IPricingPlanCommentData
    {
        public PricingPlanCommentData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        public void Create(PricingPlanComment model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_PricingPlanComment_create",
                ParametersBuilder.With("CreatedBy", auth.CurrentUserId)
                    .And("Comment", model.Comment)
                    .And("Rating", model.Rating)
                    .And("CommentBy", model.CommentBy)
            );
        }

        public ProductDetailViewModel Get(string planCode)
        {
            var auxData = DependencyResolver.Obj.Resolve<IPricingPlanData>();
            var pricingPlan = auxData.GetByCode(planCode);

            var comments = this.uow.GetDirect("sp_PricingPlanComment_get", this.Fetch, ParametersBuilder.With("PricingPlanCode", planCode));

            comments.ForEach(comment =>
            {
                comment.PricingPlan = pricingPlan;
            });

            var viewModel = new ProductDetailViewModel
            {
                PricingPlan = pricingPlan,
                Comments = comments,
                AverageRating = pricingPlan.AverageRating
            };

            return viewModel;
        }

        protected PricingPlanComment Fetch(IDataReader reader)
        {
            var record = new PricingPlanComment
            {
                Id = reader.GetInt32("Id"),
                Rating = reader.GetInt32("Rating"),
                CreatedBy = reader.GetInt32("CreatedBy"),
                Comment = reader.GetString("Comment"),
                CommentBy = reader.GetString("CommentBy"),
                CreatedDate = reader.GetDateTime("CreatedDate"),
            };

            return record;
        }

        public string GetCurrentUserComment()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            return this.uow.ScalarDirect("sp_PricingPlanComment_getByUser", ParametersBuilder.With("CreatedBy", auth.CurrentUserId)).AsString();
        }
    }
}
