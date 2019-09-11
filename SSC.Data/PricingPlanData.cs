using DBNostalgia;
using SSC.Common;
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
    public class PricingPlanData : IPricingPlanData
    {
        public PricingPlanData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private PricingPlan Fetch(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PricingPlan> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
