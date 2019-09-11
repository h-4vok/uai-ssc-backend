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
    public class CreditCardController : ApiController
    {
        private ICreditCardBusiness business;

        public CreditCardController(ICreditCardBusiness business) => this.business = business;

        public ResponseViewModel Validate(CreditCard model) => throw new NotImplementedException();

        public ResponseViewModel<CreditCard> Get(int id) => throw new NotImplementedException();

        public ResponseViewModel<IEnumerable<CreditCardReportRow>> GetForClient(int clientId) => throw new NotImplementedException();

        public ResponseViewModel Post(CreditCard model) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, CreditCard model) => throw new NotImplementedException();

        public ResponseViewModel Delete(int id) => throw new NotImplementedException();
    }
}