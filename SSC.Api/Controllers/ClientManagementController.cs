using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
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

        [Route("selectableCreditCards")]
        [HttpGet]
        public ResponseViewModel<IEnumerable<SelectableCreditCardViewModel>> GetCreditCards() => this.business.GetSelectableCreditCards().ToList();

        [Route("validateCreditCard")]
        [HttpPost]
        public ResponseViewModel ValidateCreditCard(CreditCard card) => ResponseViewModel.RunAndReturn(() => this.business.ValidateCreditCard(card, false));

        [Route("validateCreditCardPayment")]
        [HttpPost]
        public ResponseViewModel ValidateCreditCardPayment(CreditCard card) => ResponseViewModel.RunAndReturn(() => this.business.ValidateCreditCard(card, true));

    }
}