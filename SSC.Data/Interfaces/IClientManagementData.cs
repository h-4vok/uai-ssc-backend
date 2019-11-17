using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IClientManagementData
    {
        ClientLandingViewModel GetLandingData(int clientId);
        PricingPlan GetPricingPlanOfClient(int clientId);
        IEnumerable<SelectableCreditCardViewModel> GetSelectableCreditCards();
        IEnumerable<CreditCard> GetAllCreditCards();
        DateTime GetCurrentServiceExpirationTime(int clientId);
        void UpdateServiceExpirationTime(int clientId, DateTime newDate);
    }
}
