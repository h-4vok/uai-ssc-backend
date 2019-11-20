using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSC.Common.ViewModels;
using SSC.Models;

namespace SSC.Business.Interfaces
{
    public interface IProductQuestionBusiness
    {
        void Post(ProductQuestion model);
        void Reply(ProductQuestion model);
        IEnumerable<ProductQuestion> GetForProduct(string pricingPlanCode);
        IEnumerable<ProductQuestion> GetAll();
        ProductQuestion Get(int id);
    }
}
