using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
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
    public class ProductQuestionBusiness : IProductQuestionBusiness
    {
        public ProductQuestionBusiness(IProductQuestionData data) => this.data = data;

        protected IProductQuestionData data;

        public ProductQuestion Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<ProductQuestion> GetAll()
        {
            return this.data.GetAll();
        }

        public IEnumerable<ProductQuestion> GetForProduct(string pricingPlanCode)
        {
            return this.data.GetForProduct(pricingPlanCode);
        }

        public void Post(ProductQuestion model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<ProductQuestion>.Start(model)
                .MandatoryString(x => x.QuestionBy, i10n["product-question.question-by"])
                .MandatoryString(x => x.Question, i10n["product-question.question"])
                .ThrowExceptionIfApplicable();

            this.data.Post(model);
        }

        public void Reply(ProductQuestion model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<ProductQuestion>.Start(model)
                .MandatoryString(x => x.Reply, i10n["product-question.reply"])
                .ThrowExceptionIfApplicable();

            this.data.Reply(model);
        }
    }
}
