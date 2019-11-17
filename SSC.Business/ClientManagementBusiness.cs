using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private int GetCardLengthRequired(string number)
        {
            if (number.Length < 4)
                return 19;

            if (number.StartsWith("4"))
                return 16;

            var firstTwo = number.Substring(0, 2).AsInt();

            if (firstTwo >= 34 && firstTwo <= 37 || firstTwo >= 51 && firstTwo <= 55)
                return 15;

            var firstFour = number.Substring(0, 4).AsInt();

            if (firstFour >= 2221 && firstFour <= 2720)
                return 16;

            return 15;
        }

        private int GetCvcLengthRequired(string number)
        {
            if (number.Length < 4)
                return 3;

            var firstTwo = number.Substring(0, 2).AsInt();

            if (firstTwo >= 34 && firstTwo <= 37)
                return 4;

            return 3;
        }

        public void ValidateCreditCard(CreditCard card, bool isPayment)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<CreditCard>.Start(card)
                .MandatoryString(x => x.Number, i10n["payment.credit-card-number"])
                .MinStringLength(x => x.Number, i10n["payment.credit-card.number"], GetCardLengthRequired(card.Number))
                .FailWhenClosureReturnsFalse(x => x.CCV != 0, i10n["payment.credit-card.validation.ccv-empty"])
                .MinStringLength(x => x.CCV.AsString(), i10n["payment.credit-card-ccv"], GetCvcLengthRequired(card.Number))
                .MandatoryString(x => x.ExpirationDateMMYY, i10n["payment.credit-card-expiration"])
                .FailWhenClosureReturnsFalse(x =>
                {
                    var canParseDate = DateTime.TryParseExact(x.ExpirationDateMMYY, "MMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);

                    return canParseDate;
                }, i10n["payment.credit-card.validation.date-invalid-format"])
                .FailWhenClosureReturnsFalse(x =>
                {
                    var realExpirationDate = DateTime.ParseExact(x.ExpirationDateMMYY, "MMyy", CultureInfo.InvariantCulture).AddMonths(1).AddDays(-1);

                    return DateTime.Today <= realExpirationDate;
                }, i10n["payment.credit-card.validation.expired"])
                .MandatoryString(x => x.Owner, i10n["payment.credit-card-holder"])
                .ThrowExceptionIfApplicable();

            if (!isPayment && card.Id == 0) return;

            var allCards = this.data.GetAllCreditCards();

            var cardMatch = allCards.FirstOrDefault(x => x.Number == card.Number);

            if (cardMatch == null)
                throw new UnprocessableEntityException(i10n["payment.credit-card.validation.invalid-number"]);

            Func<string, string, bool> valuesMatch = (v1, v2) => v1.ToLowerInvariant().Trim() == v2.ToLowerInvariant().Trim();

            if (!valuesMatch(card.Owner, cardMatch.Owner))
                throw new UnprocessableEntityException(i10n["payment.credit-card.validation.data-mismatch"]);

            if (!valuesMatch(card.CCV.AsString(), cardMatch.CCV.AsString()))
                throw new UnprocessableEntityException(i10n["payment.credit-card.validation.data-mismatch"]);

            if (!valuesMatch(card.ExpirationDateMMYY.AsString(), cardMatch.ExpirationDateMMYY.AsString()))
                throw new UnprocessableEntityException(i10n["payment.credit-card.validation.data-mismatch"]);

            if (card.Number == "4517666866676669")
                throw new UnprocessableEntityException(i10n["payment.credit-card.validation.declined"]);

            if (card.Number == "4111321432143214")
                throw new UnprocessableEntityException(i10n["payment.credit-card.validation.process-error"]);
        }

        public void ProcessBuy(BuyViewModel model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            if (model.CreditCard != null)
            {
                this.ValidateCreditCard(model.CreditCard, true);
            }


            var pricingPlan = DependencyResolver.Obj.Resolve<IPricingPlanData>().GetByCode(model.PricingPlanCode);
            var receiptType = new ReceiptType
            {
                Code = "purchase-bill",
                IsSale = true
            };

            var bill = new Receipt<ReceiptLine>
            {
                Client = new ClientCompany { Id = auth.CurrentClientId },
                ReceiptType = receiptType,
            }; // El number lo genera la base

            var total = pricingPlan.Price;
            decimal discount = 0;
            decimal finalTotal = total;

            if (model.isAnualBuy)
            {
                discount = pricingPlan.Price.AsDecimal() * (pricingPlan.AnualDiscountPercentage.AsDecimal() / 100);
                finalTotal = total - discount;
            }

            bill.Lines.Add(new ReceiptLine
            {
                Concept = String.Format("Servicio {0} - {1}", pricingPlan.Name, model.isAnualBuy ? "Extensión 12 Meses" : "Extensión 1 Mes"),
                Subtotal = total,
                Taxes = finalTotal * 0.21.AsDecimal()
            });

            if (discount > 0)
            {
                bill.Lines.Add(new ReceiptLine
                {
                    Concept = String.Format("Descuento Extensión Anual - {0}", pricingPlan.Name),
                    Subtotal = -discount,
                    Taxes = 0
                });
            }

            var receiptBusiness = DependencyResolver.Obj.Resolve<IReceiptData>();
            receiptBusiness.CreateNewBill(bill);

            // Save credit card if needed
            if (model.SaveCard)
            {
                var ccBusiness = DependencyResolver.Obj.Resolve<ICreditCardBusiness>();
                model.CreditCard.Client = new ClientCompany { Id = auth.CurrentClientId };
                ccBusiness.Create(model.CreditCard);
            }

            // Generate related transaction
            var transaction = new ClientTransaction
            {
                ClientCompany = new ClientCompany
                {
                    Id = auth.CurrentClientId
                },
                Receipt = bill,
                Total = bill.Lines.Sum(x => x.GetTotal()),
                TransactionType = new TransactionType { Description = "Compra" },
            };

            // Setup payments
            if (model.CreditCard?.Id > 0)
            {
                transaction.Payments.Add(new ClientTransactionPayment
                {
                    CreditCard = model.CreditCard,
                    Amount = finalTotal
                });
            }
            else if (model.CreditCard != null )
            {
                transaction.Payments.Add(new ClientTransactionPayment
                {
                    Number = model.CreditCard.Number,
                    Owner = model.CreditCard.Owner,
                    CCV = model.CreditCard.CCV,
                    ExpirationDateMMYY = model.CreditCard.ExpirationDateMMYY,
                    Amount = transaction.Total
                });
            }

            // TODO: Setup credit notes
            // TODO: When credit notes are added, the amount of client transaction payment changes

            // Save transaction
            {
                var trBusiness = DependencyResolver.Obj.Resolve<IClientTransactionBusiness>();
                trBusiness.Create(transaction);
            }

            // Calculate new service expiration date for client
            var serviceTime = this.data.GetCurrentServiceExpirationTime(auth.CurrentClientId);

            if (model.isAnualBuy)
            {
                serviceTime = serviceTime.AddMonths(12);
            }
            else
            {
                serviceTime = serviceTime.AddMonths(1);
            }

            this.data.UpdateServiceExpirationTime(auth.CurrentClientId, serviceTime);

            // Send email saying what we bought
        }
    }
}
