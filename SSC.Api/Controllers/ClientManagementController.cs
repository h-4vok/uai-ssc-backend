using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    [RoutePrefix("api/clientmanagement")]
    public class ClientManagementController : ApiController
    {
        public ClientManagementController(IClientManagementBusiness business) => this.business = business;

        protected IClientManagementBusiness business;

        [Route("")]
        [HttpGet]
        public ResponseViewModel<ClientLandingViewModel> Get() => this.business.GetLandingData();

        [Route("selectablePrices")]
        [HttpGet]
        public ResponseViewModel<SelectablePricesViewModel> GetSelectablePrices() => this.business.GetSelectablePrices();

        [Route("profitReport")]
        [HttpGet]
        public ResponseViewModel<IEnumerable<ProfitReportRow>> GetProfitReport(string dateFrom, string dateTo) => 
            this.business.GetProfitReport(dateFrom, dateTo).ToList();

        [Route("generateFakeBilling")]
        [HttpGet]
        public ResponseViewModel GenerateFakeBilling()
        {
            this.business.GenerateFakeBilling();
            return true;
        }

        [Route("selectableCreditCards")]
        [HttpGet]
        public ResponseViewModel<IEnumerable<SelectableCreditCardViewModel>> GetCreditCards() => this.business.GetSelectableCreditCards().ToList();

        [Route("selectableCreditNotes")]
        [HttpGet]
        public ResponseViewModel<IEnumerable<SelectableCreditNoteViewModel>> GetCreditNotes() => this.business.GetSelectableCreditNotes().ToList();

        [Route("validateCreditCard")]
        [HttpPost]
        public ResponseViewModel ValidateCreditCard(CreditCard card) => ResponseViewModel.RunAndReturn(() => this.business.ValidateCreditCard(card, false));

        [Route("validateCreditCardPayment")]
        [HttpPost]
        public ResponseViewModel ValidateCreditCardPayment(CreditCard card) => ResponseViewModel.RunAndReturn(() => this.business.ValidateCreditCard(card, true));

        [Route("buy")]
        [HttpPost]
        public ResponseViewModel Buy(BuyViewModel model) => ResponseViewModel.RunAndReturn(() => this.business.ProcessBuy(model));

        [Route("billforprinting/{receiptId}")]
        [HttpGet]
        public ResponseViewModel<PrintableBillViewModel> Get(int receiptId) => this.business.GetPrintableBill(receiptId);

        [Route("billdetailforreturn/{receiptId}")]
        [HttpGet]
        public ResponseViewModel<BillDetailForReturnViewModel> GetDetailForReturn(int receiptId) => 
            ResponseViewModel.RunAndReturn(() => this.business.GetDetailForReturn(receiptId));

        [Route("returnbillrequest/{receiptId}")]
        [HttpPut]
        public ResponseViewModel StartReturnRequest(int receiptId) => ResponseViewModel.RunAndReturn(() => this.business.StartReturnRequest(receiptId));

    }
}