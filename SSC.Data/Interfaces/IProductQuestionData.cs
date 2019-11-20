using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSC.Common.ViewModels;
using SSC.Models;

namespace SSC.Data.Interfaces
{
    public interface IProductQuestionData
    {
        ProductQuestion Get(int id);
        IEnumerable<ProductQuestion> GetAll();
        IEnumerable<ProductQuestion> GetForProduct(string pricingPlanCode);
        void Post(ProductQuestion model);
        void Reply(ProductQuestion model);
    }
}
