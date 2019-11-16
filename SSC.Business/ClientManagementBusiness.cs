using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class ClientManagementBusiness : IClientManagementBusiness
    {
        public ClientManagementBusiness(IClientManagementData data) => this.data = data;

        protected IClientManagementData data;

        public ClientLandingViewModel GetLandingData()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            return this.data.GetLandingData(auth.CurrentClientId);
        }

        public SelectablePricesViewModel GetSelectablePrices()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var pricingPlan = this.data.GetPricingPlanOfClient(auth.CurrentClientId);

            Func<decimal> asDiscountPercentage = () =>
            {
                var fullPart = pricingPlan.AnualDiscountPercentage.GetValueOrDefault().AsDecimal() / 100;
                var discount = 1 - fullPart;

                return discount;
            };

            var model = new SelectablePricesViewModel
            {
                Month = new SelectablePriceViewModel
                {
                    Code = pricingPlan.Code,
                    Price = pricingPlan.Price.AsInt()
                },
                Year = new SelectablePriceViewModel
                {
                    Code = pricingPlan.Code,
                    Price = (pricingPlan.Price * 12 * asDiscountPercentage()).AsInt()
                }
            };

            return model;
        }

        public IEnumerable<SelectableCreditCardViewModel> GetSelectableCreditCards()
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
            var cards = this.data.GetSelectableCreditCards();
            var newCardOption = new SelectableCreditCardViewModel
            {
                value = 0,
                label = i10n["payment.new-credit-card"],
            };

            Func<string, string> formatNumber = number =>
            {
                var lengthMinus4 = number.Length - 4;
                var format = String.Format("{0}{1}", "".PadLeft(lengthMinus4, 'X'), number.Substring(Math.Max(0, number.Length - 4)));

                return format;
            };

            cards.ForEach(card =>
            {
                card.label = formatNumber(card.CreditCard.Number);
                card.value = card.CreditCard.Id;
            });

            var output = new List<SelectableCreditCardViewModel>();
            output.Add(newCardOption);
            output.AddRange(cards);

            return output;
        }
    }
}
