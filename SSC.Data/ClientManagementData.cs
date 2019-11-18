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
                Total = reader.GetDecimal(reader.GetOrdinal("Total")).ToString("$ #.00"),
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
            model.FormattedTransactionDate = reader.GetDateTime("TransactionDate").ToString("dd/MM/yyyy");
            model.ClientLegalName = reader.GetString("LegalName");
            model.ClientTaxCode = reader.GetString("TaxCode");

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
    }
}
