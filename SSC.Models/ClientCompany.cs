using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClientCompany : AuditableEntity
    {
        public string Name { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public PricingPlan CurrentPricingPlan { get; set; }
        public bool IsEnabled { get; set; }
        public IEnumerable<CreditCard> OtherCreditCards { get; set; }
        public ClientCompanyBillingInformation BillingInformation { get; set; }
        public CreditCard DefaultCreditCard { get; set; }
        public string ApiToken { get; set; }
    }
}
