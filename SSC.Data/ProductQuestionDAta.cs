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
    public class ProductQuestionData : IProductQuestionData
    {
        public ProductQuestionData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        protected ProductQuestion Fetch(IDataReader reader)
        {
            var record = new ProductQuestion
            {
                Id = reader.GetInt32("Id"),
                PricingPlanCode = reader.GetString("PricingPlanCode"),
                PricingPlanId = reader.GetInt32("PricingPlanId"),
                PricingPlanName = reader.GetString("PricingPlanName"),
                Question = reader.GetString("Question"),
                QuestionBy = reader.GetString("QuestionBy"),
                PostedDate = reader.GetDateTime("PostedDate"),
                RepliedDate = reader.GetDateTimeNullable("RepliedDate"),
                Reply = reader.GetString("Reply"),
                ReplyBy = reader.GetInt32Nullable("ReplyBy"),
                ReplyByDescription = reader.GetString("ReplyByDescription")
            };

            return record;
        }

        public ProductQuestion Get(int id)
        {
            return this.uow.GetOneDirect("sp_ProductQuestion_getOne",
                this.Fetch,
                ParametersBuilder.With("Id", id)
            );
        }

        public IEnumerable<ProductQuestion> GetAll()
        {
            return this.uow.GetDirect("sp_ProductQuestion_getAll", this.Fetch);
        }

        public IEnumerable<ProductQuestion> GetForProduct(string pricingPlanCode)
        {
            return this.uow.GetDirect("sp_ProductQuestion_getForProduct", this.Fetch, ParametersBuilder.With("PricingPlanCode", pricingPlanCode));
        }

        public void Post(ProductQuestion model)
        {
            this.uow.NonQueryDirect("sp_ProductQuestion_post",
                ParametersBuilder.With("QuestionBy", model.QuestionBy)
                .And("Question", model.Question).And("PricingPlanCode", model.PricingPlanCode)
            );
        }

        public void Reply(ProductQuestion model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_ProductQuestion_reply",
                ParametersBuilder.With("Id", model.Id)
                .And("Reply", model.Reply)
                .And("ReplyBy", auth.CurrentUserId)
            );
        }
    }
}
