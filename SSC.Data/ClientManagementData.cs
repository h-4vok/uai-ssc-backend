using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
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
    public class ClientManagementData : IClientManagementData
    {
        public ClientManagementData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        protected ClientLandingViewModel FetchClientLanding(IDataReader reader) =>
            new ClientLandingViewModel
            {
                ServicePlanName = reader.GetString("ServicePlanName"),
                ServiceExpirationDescription = reader.GetDateTime("ServiceExpirationDescription").ToString("dd/MM/yyyy")
            };

        protected ClientTransactionReportRow FetchTransactionRow(IDataReader reader)
        {
            var record = new ClientTransactionReportRow
            {
                TransactionId = reader.GetInt32("TransactionId"),
                ReceiptId = reader.GetInt32("ReceiptId"),
                ReceiptNumber = reader.GetString("ReceiptNumber").AsInt().ToString("A0001-0000####"),
                Total = (-reader.GetDecimal(reader.GetOrdinal("Total"))).ToString("$ #.00"),
                TransactionDate = reader.GetDateTime("TransactionDate").ToString("yyyy-MM-dd"),
                TransactionDescription = reader.GetString("TransactionDescription"),
                TransactionTypeCode = reader.GetString("TransactionTypeCode"),
                TransactionStatusCode = reader.GetString("TransactionStatusCode")
            };

            return record;
        }

        public ClientLandingViewModel GetLandingData(int clientId)
        {
            var viewModel = this.uow.GetOneDirect("sp_ClientManagement_getLandingData",
                this.FetchClientLanding,
                ParametersBuilder.With("ClientId", clientId));

            viewModel.Transactions = this.uow.GetDirect("sp_ClientManagement_getTransactions",
                this.FetchTransactionRow,
                ParametersBuilder.With("ClientId", clientId)
            );

            return viewModel;
        }

        protected PricingPlan FetchPricingPlan(IDataReader reader) =>
            new PricingPlan
            {
                Code = reader.GetString("Code"),
                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                AnualDiscountPercentage = reader.GetInt32Nullable("AnualDiscountPercentage")
            };

        public PricingPlan GetPricingPlanOfClient(int clientId)
        {
            return this.uow.GetOneDirect("sp_ClientManagement_getPricingPlanOfClient",
                this.FetchPricingPlan,
                ParametersBuilder.With("ClientId", clientId)
            );
        }

        protected SelectableCreditCardViewModel FetchCreditCardViewModel(IDataReader reader) =>
            new SelectableCreditCardViewModel
            {
                CreditCard = this.FetchCreditCard(reader)
            };

        protected CreditCard FetchCreditCard(IDataReader reader) =>
            new CreditCard
            {
                Id = reader.GetInt32("Id"),
                Owner = reader.GetString("Owner"),
                Number = reader.GetString("Number"),
                ExpirationDateMMYY = reader.GetString("ExpirationDateMMYY"),
                CCV = reader.GetInt32("CCV"),
            };

        public IEnumerable<SelectableCreditCardViewModel> GetSelectableCreditCards()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            return this.uow.GetDirect("sp_ClientManagement_getClientCreditCards",
                this.FetchCreditCardViewModel,
                ParametersBuilder.With("ClientId", auth.CurrentClientId)
            );
        }

        public IEnumerable<CreditCard> GetAllCreditCards()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var approvedCards = this.uow.GetDirect("sp_ClientManagement_getApprovedCards", this.FetchCreditCard);
            var clientCards = this.uow.GetDirect("sp_ClientManagement_getClientCards", this.FetchCreditCard, ParametersBuilder.With("ClientId", auth.CurrentClientId));

            var merged = new List<CreditCard>();
            merged.AddRange(approvedCards);
            merged.AddRange(clientCards);

            return merged;
        }

        public DateTime GetCurrentServiceExpirationTime(int clientId)
        {
            return Convert.ToDateTime(
                this.uow.ScalarDirect("sp_ClientCompany_getServiceExpiration",
                ParametersBuilder.With("ClientId", clientId)));
        }

        public void UpdateServiceExpirationTime(int clientId, DateTime newDate)
        {
            this.uow.NonQueryDirect("sp_ClientCompany_updateServiceExpiration",
                ParametersBuilder.With("ServicePlanExpirationTime", newDate)
                    .And("ClientId", clientId)
            );
        }

        protected PrintableBillViewModel FetchBillHeader(IDataReader reader)
        {
            var model = new PrintableBillViewModel();

            model.ReceiptNumber = reader.GetString("ReceiptNumber").AsInt().ToString("A0001-0000####");
            model.ReceiptTypeDescription = reader.GetString("ReceiptTypeDescription");
            model.FormattedTransactionDate = reader.GetDateTime("TransactionDate").ToString("dd/MM/yyyy");
            model.ClientLegalName = reader.GetString("LegalName");
            model.ClientTaxCode = reader.GetString("TaxCode");
            model.IsNullified = reader.GetBoolean("IsNullified");

            var city = reader.GetString("City");
            var streetName = reader.GetString("StreetName");
            var streetNumber = reader.GetString("StreetNumber");
            var postalCode = reader.GetString("PostalCode");
            var department = reader.GetString("Department");
            var province = reader.GetString("ProvinceName");

            var items = new[] { streetName, streetNumber, department, postalCode, city, province };
            model.ClientCompositeAddress = String.Join(", ", items);

            model.IsCreditCardSale = reader.GetBoolean("IsCreditCardSale");
            model.IsCreditNoteSale = reader.GetBoolean("IsCreditNoteSale");

            model.FormattedTotal = reader.GetDecimal(reader.GetOrdinal("Total")).ToString("#.00");

            return model;
        }

        private class PrintableBillStagingLine
        {
            public int Quantity { get; set; }
            public string Detail { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalPrice { get; set; }
            public decimal LineTaxes { get; set; }
        }

        private PrintableBillStagingLine FetchBillStagingLine(IDataReader reader) =>
            new PrintableBillStagingLine
            {
                Quantity = reader.GetInt32("Quantity"),
                Detail = reader.GetString("Detail"),
                UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                LineTaxes = reader.GetDecimal(reader.GetOrdinal("LineTaxes")),
            };

        public PrintableBillViewModel GetBillForPrinting(int receiptId)
        {
            return this.uow.Run(() =>
            {
                var model = this.uow.GetOne("sp_PrintableBill_getHeader", this.FetchBillHeader, ParametersBuilder.With("ReceiptId", receiptId));
                var stagingLines = this.uow.Get("sp_PrintableBill_getLines", this.FetchBillStagingLine, ParametersBuilder.With("ReceiptId", receiptId));

                stagingLines.ForEach(sl =>
                {
                    var line = new PrintableBillLineViewModel
                    {
                        Quantity = sl.Quantity,
                        Detail = sl.Detail,
                        FormattedUnitPrice = sl.UnitPrice.ToString("#.00"),
                        FormattedTotalPrice = sl.TotalPrice.ToString("#.00")
                    };

                    model.Lines.Add(line);
                });

                model.FormattedSubtotal = stagingLines.Sum(x => x.TotalPrice).ToString("#.00");
                model.FormattedVAT = stagingLines.Sum(x => x.LineTaxes).ToString("#.00");
                model.FormattedTotal = stagingLines.Sum(x => x.TotalPrice + x.LineTaxes).ToString("#.00");

                return model;
            });
        }

        public bool ReturnForReceiptExists(int receiptId)
        {
            return this.uow.ScalarDirect("sp_BillReturn_exists", ParametersBuilder.With("ReceiptId", receiptId)).AsBool();
        }

        protected BillDetailForReturnViewModel FetchBillDetailForReturn(IDataReader reader)
        {
            var model = new BillDetailForReturnViewModel
            {
                ReceiptNumber = reader.GetString("ReceiptNumber").AsInt().ToString("A0001-0000####"),
                ItemDescription = reader.GetString("ItemDescription"),
                TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")).ToString("U$D #.00")
            };

            return model;
        }

        public BillDetailForReturnViewModel GetDetailForReturn(int receiptId)
        {
            return this.uow.GetOneDirect("sp_BillReturn_getDetail", this.FetchBillDetailForReturn, ParametersBuilder.With("ReceiptId", receiptId));
        }

        public void StartReturnRequest(int receiptId)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            this.uow.NonQueryDirect("sp_StartReturnRequest",
                ParametersBuilder.With("ReceiptId", receiptId)
                    .And("RequestedBy", auth.CurrentUserId)
            );
        }

        private string formatNumberIfExists(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return null;

            return number.AsInt().ToString("A0001-0000####");
        }

        protected ReceiptReturnRequestViewModel FetchRRR(IDataReader reader) =>
            new ReceiptReturnRequestViewModel
            {
                Id = reader.GetInt32("Id"),
                ReceiptId = reader.GetInt32("ReceiptId"),
                Approved = reader.GetBoolean("Approved"),
                ApprovedBy = reader.GetString("ApprovedBy"),
                ReceiptNumber = reader.GetString("ReceiptNumber").AsInt().ToString("A0001-0000####"),
                Rejected = reader.GetBoolean("Rejected"),
                RejectedBy = reader.GetString("RejectedBy"),
                RequestDate = reader.GetDateTime("RequestDate"),
                RequestedBy = reader.GetString("RequestedBy"),
                ReviewDate = reader.GetDateTimeNullable("ReviewDate"),
                RelatedCreditNoteNumber = formatNumberIfExists(reader.GetString("RelatedCreditNoteNumber")),
                RelatedCreditNoteId = reader.GetInt32Nullable("RelatedCreditNoteId")
            };

        public IEnumerable<ReceiptReturnRequestViewModel> GetReceiptReturnRequests()
        {
            return this.uow.GetDirect("sp_ReceiptReturnRequest_getAll", this.FetchRRR);
        }

        public AfterReturnApproval ApproveReturn(int receiptId)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var output = new AfterReturnApproval();

            this.uow.Run(() =>
            {
                // modificamos el registro
                output.ClientUserId = this.uow.Scalar("sp_ReceiptReturnRequest_approve",
                    ParametersBuilder.With("ReceiptId", receiptId)
                    .And("ApprovedBy", auth.CurrentUserId)
                ).AsInt();

                // anulamos la factura original
                var clientId = this.uow.Scalar("sp_Receipt_nullify",
                    ParametersBuilder.With("ReceiptId", receiptId)).AsInt();

                // generamos el encabezado de NC
                var ncId = this.uow.Scalar("sp_Receipt_create",
                    ParametersBuilder.With("ClientId", clientId)
                        .And("ReceiptTypeCode", "credit-note")
                        .And("CreatedBy", auth.CurrentUserId)
                ).AsInt();

                // obtenemos numero de factura
                var receiptNumber = this.uow.Scalar("sp_Receipt_getNumber", ParametersBuilder.With("Id", receiptId)).AsString();
                output.NullifiedReceiptNumber = receiptNumber.AsInt().ToString("A0001-0000####");

                // generamos la linea del NC
                var ncLine = new ReceiptLine();
                {
                    var stagingLines = this.uow.Get("sp_PrintableBill_getLines", this.FetchBillStagingLine, ParametersBuilder.With("ReceiptId", receiptId));

                    ncLine.Subtotal = stagingLines.Sum(x => x.TotalPrice);
                    ncLine.Taxes = stagingLines.Sum(x => x.LineTaxes);
                }
                this.uow.NonQuery("sp_ReceiptLine_create",
                    ParametersBuilder.With("ReceiptId", ncId)
                        .And("Concept", String.Format("Devolución Factura {0}", output.NullifiedReceiptNumber))
                        .And("Subtotal", -ncLine.Subtotal)
                        .And("Taxes", -ncLine.Taxes)
                        .And("CreatedBy", auth.CurrentUserId)
                );
                output.CreditNoteNumber = this.uow.Scalar("sp_Receipt_getNumber", ParametersBuilder.With("Id", ncId)).AsString().AsInt().ToString("A0001-0000####");

                // generamos la transaccion del NC
                this.uow.NonQuery("sp_ClientTransaction_create",
                    ParametersBuilder.With("TransactionTypeCode", "Retorno")
                        .And("Total", -(ncLine.Subtotal + ncLine.Taxes))
                        .And("ClientId", clientId)
                        .And("ReceiptId", ncId)
                        .And("RelatedReceiptId", receiptId)
                );

                // actualizamos el expiration date del cliente
                var monthsBought = this.uow.Scalar("sp_Receipt_getBoughtMonths", ParametersBuilder.With("ReceiptId", receiptId)).AsInt();
                var currentDate = Convert.ToDateTime(this.uow.Scalar("sp_ClientCompany_getServiceExpiration", ParametersBuilder.With("ClientId", clientId)));

                var days = monthsBought * 30;
                var newDate = currentDate.Subtract(new TimeSpan(days, 0, 0, 0));

                this.uow.NonQuery("sp_ClientCompany_updateExpirationDate",
                    ParametersBuilder.With("Id", clientId)
                        .And("ServiceExpirationDate", newDate)
                );
            }, true);

            return output;
        }

        public ReturnApprovalRequiredData GetReturnApprovedRequiredData(int receiptId)
        {
            var clientId = this.uow.ScalarDirect("sp_Receipt_getClientId", ParametersBuilder.With("ReceiptId", receiptId)).AsInt();
            var monthsBought = this.uow.ScalarDirect("sp_Receipt_getBoughtMonths", ParametersBuilder.With("ReceiptId", receiptId)).AsInt();
            var currentDate = Convert.ToDateTime(this.uow.ScalarDirect("sp_ClientCompany_getServiceExpiration", ParametersBuilder.With("ClientId", clientId)));
            var days = monthsBought * 30;

            var model = new ReturnApprovalRequiredData
            {
                ClientId = clientId,
                ReceiptId = receiptId,
                DaysToReturn = days,
                CurrentExpirationDate = currentDate
            };

            return model;

        }

        public bool IsPurchaseBill(int receiptId)
        {
            return this.uow.ScalarDirect("sp_Receipt_isPurchaseBill", ParametersBuilder.With("Id", receiptId)).AsBool();
        }

        public Tuple<int, string> RejectReturn(int receiptId)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            var userId = this.uow.ScalarDirect("sp_ReceiptReturnRequest_reject",
                    ParametersBuilder.With("ReceiptId", receiptId)
                    .And("RejectedBY", auth.CurrentUserId)
                ).AsInt();

            var receiptNumber = this.uow.ScalarDirect("sp_Receipt_getNumber", ParametersBuilder.With("Id", receiptId)).AsString();
            var finalReceiptNumber = receiptNumber.AsInt().ToString("A0001-0000####");

            var output = new Tuple<int, string>(userId, finalReceiptNumber);
            return output;
        }

        protected SelectableCreditNoteViewModel FetchSelectableCreditNote(IDataReader reader) =>
            new SelectableCreditNoteViewModel(
                reader.GetInt32("CreditNoteId"), 
                reader.GetString("CreditNoteNumber"), 
                reader.GetDecimal(reader.GetOrdinal("Amount")));

        public IEnumerable<SelectableCreditNoteViewModel> GetSelectableCreditNotes()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            return this.uow.GetDirect("sp_ClientManagement_getSelectableCreditNotes", this.FetchSelectableCreditNote, ParametersBuilder.With("ClientId", auth.CurrentClientId));
        }

        public void NullifyCreditNote(int id)
        {
            this.uow.NonQueryDirect("sp_CreditNote_nullify", ParametersBuilder.With("CreditNoteId", id));
        }

        public void CreateCreditNoteFromPurchaseSurplus(decimal remainderForNewCreditNote, string purchaseReceiptNumber)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var clientId = auth.CurrentClientId;

            this.uow.Run(() =>
            {
                // generamos el encabezado de NC
                var ncId = this.uow.Scalar("sp_Receipt_create",
                    ParametersBuilder.With("ClientId", clientId)
                        .And("ReceiptTypeCode", "credit-note")
                        .And("CreatedBy", auth.CurrentUserId)
                ).AsInt();

                this.uow.NonQuery("sp_ReceiptLine_create",
                    ParametersBuilder.With("ReceiptId", ncId)
                        .And("Concept", String.Format("Exceso Compra Factura {0}", purchaseReceiptNumber))
                        .And("Subtotal", -remainderForNewCreditNote)
                        .And("Taxes", 0)
                        .And("CreatedBy", auth.CurrentUserId)
                );

                // generamos la transaccion del NC
                this.uow.NonQuery("sp_ClientTransaction_create",
                    ParametersBuilder.With("TransactionTypeCode", "Retorno")
                        .And("Total", -remainderForNewCreditNote)
                        .And("ClientId", clientId)
                        .And("ReceiptId", ncId)
                );
            }, true);
        }

        protected ProfitReportRow FetchProfitReportRow(IDataReader reader) =>
            new ProfitReportRow
            {
                Date = reader.GetDateTime("Date"),
                Profit = reader.GetDecimal(reader.GetOrdinal("Profit"))
            };

        public IEnumerable<ProfitReportRow> GetProfitReport(string dateFrom, string dateTo)
        {
            return this.uow.GetDirect("sp_ClientManagement_getProfitReport", this.FetchProfitReportRow,
                ParametersBuilder.With("DateFrom", dateFrom)
                    .And("DateTo", dateTo)
            );
        }

        public void CreateFakeTransaction(ClientTransaction transaction)
        {
            this.uow.NonQueryDirect("sp_ClientManagement_createFakeTransaction",
                    ParametersBuilder.With("TransactionDate", transaction.TransactionDate)
                        .And("Total", transaction.Total)
                        .And("ClientId", transaction.ClientCompany.Id)
                );
        }
    }
}
