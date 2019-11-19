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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

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
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

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

            var total = model.isAnualBuy ? pricingPlan.Price * 12 : pricingPlan.Price;
            decimal discount = 0;
            decimal finalSubtotal = total;

            if (model.isAnualBuy)
            {
                discount = total * (pricingPlan.AnualDiscountPercentage.AsDecimal() / 100);
                finalSubtotal = total - discount;
            }

            decimal finalTotalWithTaxes = finalSubtotal + (finalSubtotal * 0.21M);

            // Una vez que sabemos el final total podemos validar el tema de credit notes
            {
                if (model.CreditNotes.Count() > 0)
                {
                    var totalAmount = model.CreditNotes.Sum(x => -x.Amount);

                    if (totalAmount >= finalTotalWithTaxes && model.CreditCard != null)
                    {
                        throw new UnprocessableEntityException(i10n["buy-more.validation.combined-payment-not-needed"]);
                    }

                    if (totalAmount < finalTotalWithTaxes && model.CreditCard == null)
                    {
                        throw new UnprocessableEntityException(i10n["buy-more.validation.amount-not-met"]);
                    }

                    // Acaso estoy agregando notas de credito de mas?
                    var orderedList = model.CreditNotes.OrderByDescending(x => -x.Amount);

                    decimal orderedTotal = 0M;

                    for (var i = 0; i < orderedList.Count(); i++)
                    {
                        var creditNoteItem = orderedList.ElementAt(i);
                        orderedTotal += -creditNoteItem.Amount;

                        if (orderedTotal >= finalTotalWithTaxes && i < orderedList.Count() - 1)
                        {
                            throw new UnprocessableEntityException(i10n["buy-more.validation.too-many-credit-notes"]);
                        }
                    }

                }
            }

            // Seguimos con la factura
            bill.Lines.Add(new ReceiptLine
            {
                Concept = String.Format("Servicio {0} - {1}", pricingPlan.Name, model.isAnualBuy ? "Extensión 12 Meses" : "Extensión 1 Mes"),
                Subtotal = total,
                Taxes = finalSubtotal * 0.21.AsDecimal()
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

            // Setup credit note payments
            var orderedCreditNotes = model.CreditNotes.OrderByDescending(x => -x.Amount);

            decimal remainingTotal = finalTotalWithTaxes;

            for (var i = 0; i < orderedCreditNotes.Count(); i++)
            {
                var creditNoteItem = orderedCreditNotes.ElementAt(i);
                var positiveAmount = -creditNoteItem.Amount;

                remainingTotal -= positiveAmount;

                decimal amountToSet;

                if (remainingTotal >= 0)
                {
                    amountToSet = positiveAmount;
                }
                else
                {
                    amountToSet = positiveAmount - remainingTotal;
                }

                transaction.Payments.Add(new ClientTransactionPayment
                {
                    CreditNoteId = creditNoteItem.value,
                    Amount = amountToSet
                });
            }

            // Credit card pays the remaining
            var transactionAmountSoFar = transaction.Payments.Sum(x => x.Amount);
            var remainingAmount = finalTotalWithTaxes - transactionAmountSoFar;

            // Setup credit card payment
            if (model.CreditCard?.Id > 0)
            {
                transaction.Payments.Add(new ClientTransactionPayment
                {
                    CreditCard = model.CreditCard,
                    Amount = remainingAmount
                });
            }
            else if (model.CreditCard != null)
            {
                transaction.Payments.Add(new ClientTransactionPayment
                {
                    Number = model.CreditCard.Number,
                    Owner = model.CreditCard.Owner,
                    CCV = model.CreditCard.CCV,
                    ExpirationDateMMYY = model.CreditCard.ExpirationDateMMYY,
                    Amount = remainingAmount
                });
            }

            // Save transaction
            {
                var trBusiness = DependencyResolver.Obj.Resolve<IClientTransactionBusiness>();
                trBusiness.Create(transaction);
            }

            // Nullify credit notes
            foreach(var creditNoteItem in model.CreditNotes)
            {
                this.data.NullifyCreditNote(creditNoteItem.value);
            }

            // Should I create a new one?
            var creditNotesSum = model.CreditNotes.Sum(x => -x.Amount);
            var remainderForNewCreditNote = creditNotesSum - finalTotalWithTaxes;

            if(creditNotesSum > 0 && remainderForNewCreditNote > 0)
            {
                this.data.CreateCreditNoteFromPurchaseSurplus(remainderForNewCreditNote, bill.Number.AsInt().ToString("A0001-0000####"));
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
            {
                var receiptNumber = bill.Number.AsInt().ToString("A0001-0000####");

                var mailTemplatePath = HostingEnvironment.MapPath(String.Format("~/EmailTemplates/purchase-finished_{0}.html", auth.CurrentLanguageCode));
                var mailTemplate = File.ReadAllText(mailTemplatePath);
                var lineTemplatePath = HostingEnvironment.MapPath("~/EmailTemplates/purchase-line.html");
                var lineTemplate = File.ReadAllText(lineTemplatePath);

                // Build lines
                var linesParts = new StringBuilder();

                bill.Lines.ForEach(line =>
                {
                    var part = lineTemplate;
                    part = part.Replace("${PurchaseDetailLine}", line.Concept);
                    part = part.Replace("${PurchaseDetailPrice}", line.Subtotal.ToString("$#.00"));

                    linesParts.Append(part);

                    if (line.Taxes > 0)
                    {
                        var taxPart = lineTemplate;
                        taxPart = taxPart.Replace("${PurchaseDetailLine}", line.Concept + " - IVA");
                        taxPart = taxPart.Replace("${PurchaseDetailPrice}", line.Taxes.ToString("$#.00"));

                        linesParts.Append(taxPart);
                    }
                });

                // Build payment lines
                var paymentParts = new StringBuilder();

                transaction.Payments.ForEach(payment =>
                {
                    var isCreditNote = payment.CreditNoteId.HasValue;

                    var part = lineTemplate;
                    part = part.Replace("${PurchaseDetailLine}", isCreditNote ? i10n["purchase.payment-part.credit-note"] : i10n["purchase.payment-part.credit-card"]);

                    if (isCreditNote)
                    {
                            // la tenemos que ir a buscar
                            //.ToString("A0001-0000####")
                        }
                    else
                    {
                        var number = payment.CreditCard?.Number ?? payment.Number;
                        var fmt = new String('X', number.Length - 4) + number.Substring(number.Length - 4);

                        part = part.Replace("${PurchaseDetailPrice}", fmt);
                    }

                    paymentParts.Append(part);
                });

                // Finish up mail
                mailTemplate = mailTemplate.Replace("${ExtensionType}", model.isAnualBuy ? i10n["purchase.extension.year"] : i10n["purchase.extension.month"]);
                mailTemplate = mailTemplate.Replace("${ServicePlanName}", pricingPlan.Name);
                mailTemplate = mailTemplate.Replace("${SscBillLink}", String.Format("http://{0}/#/client-management/bill/{1}", model.IncomingHost, bill.Id));
                mailTemplate = mailTemplate.Replace("${ReceiptLines}", linesParts.ToString());
                mailTemplate = mailTemplate.Replace("${TotalAmount}", transaction.Total.ToString("$#.00"));
                mailTemplate = mailTemplate.Replace("${PaidWithLines}", paymentParts.ToString());
                mailTemplate = mailTemplate.Replace("${BillNumber}", receiptNumber);

                // Send email
                var smtpHandler = DependencyResolver.Obj.Resolve<ISmtpHandler>();

                var mail = new QueuedMail
                {
                    To = auth.CurrentUserName,
                    Subject = i10n["newsletter-email.subject"],
                    Body = mailTemplate,
                };

                smtpHandler.Send(mail, true);
            }
        }

        public PrintableBillViewModel GetPrintableBill(int receiptId)
        {
            return this.data.GetBillForPrinting(receiptId);
        }

        public BillDetailForReturnViewModel GetDetailForReturn(int receiptId)
        {
            // es otro cbte que no es una factura?
            if (!this.data.IsPurchaseBill(receiptId))
            {
                var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
                throw new UnprocessableEntityException(i10n["request-for-return.validation.not-purchase-bill"]);
            }

            // existe el retorno? tiro exception
            if (this.data.ReturnForReceiptExists(receiptId))
            {
                var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
                throw new UnprocessableEntityException(i10n["request-for-return.validation.already-exists"]);
            }

            // retorno el modelo desde data
            return this.data.GetDetailForReturn(receiptId);
        }

        public void StartReturnRequest(int receiptId)
        {
            // existe el retorno? tiro exception
            if (this.data.ReturnForReceiptExists(receiptId))
            {
                var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
                throw new UnprocessableEntityException(i10n["request-for-return.validation.already-exists"]);
            }

            this.data.StartReturnRequest(receiptId);
        }

        public IEnumerable<ReceiptReturnRequestViewModel> GetReceiptReturnRequests()
        {
            return this.data.GetReceiptReturnRequests();
        }

        public void ApproveReturn(int receiptId, Action<int, string, string> callback)
        {
            // revisamos que al hacer la devolucion no lleguemos a una fecha de expiracion anterior a hoy
            var returnData = this.data.GetReturnApprovedRequiredData(receiptId);
            if (returnData.CurrentExpirationDate.Subtract(new TimeSpan(returnData.DaysToReturn, 0, 0, 0, 0)) < DateTime.Today)
            {
                var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
                throw new UnprocessableEntityException(i10n["receipt-return-request.validation.bad-expiration-after"]);
            }

            // aprobamos
            var output = this.data.ApproveReturn(receiptId);

            // mandamos mensaje al chat
            callback(output.ClientUserId, output.NullifiedReceiptNumber, output.CreditNoteNumber);
        }

        public void RejectReturn(ReturnRejectionViewModel viewModel, Action<int, string, string> sendRejectionMessageToClient)
        {
            if (viewModel.RejectionMotive.Length < 50)
            {
                var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
                throw new UnprocessableEntityException(i10n["receipt-return-request.validation.rejection-motive-too-short"]);
            }

            Tuple<int, string> rejectionData = this.data.RejectReturn(viewModel.ReceiptId);

            sendRejectionMessageToClient(rejectionData.Item1, rejectionData.Item2, viewModel.RejectionMotive);
        }

        public IEnumerable<SelectableCreditNoteViewModel> GetSelectableCreditNotes()
        {
            return this.data.GetSelectableCreditNotes();
        }
    }
}
