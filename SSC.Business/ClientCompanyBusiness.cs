using SSC.Business.Interfaces;
using SSC.Common;
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
    public class ClientCompanyBusiness : IClientCompanyBusiness
    {
        public ClientCompanyBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IClientCompanyData>();
        }
        private IClientCompanyData data;

        public int Create(ClientCompany model)
        {
            if (model.CurrentPricingPlan.Id <= 0)
            {
                var pricingPlanBusiness = DependencyResolver.Obj.Resolve<IPricingPlanBusiness>();
                model.CurrentPricingPlan = pricingPlanBusiness.GetByCode(model.CurrentPricingPlan.Code);
            }

            return this.data.Create(model);
        }

        public IEnumerable<ClientCompanyReportRow> GetAll()
        {
            return this.data.GetAll();
        }

        public ClientBalanceReport GetBalanceReport(int id)
        {
            throw new NotImplementedException();
        }

        public ClientCompanyBillingInformation GetBillingInformation(int clientId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBillingInformation(ClientCompanyBillingInformation model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
