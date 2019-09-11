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
    public class ClientTransactionController : ApiController
    {
        private IClientTransactionBusiness business;

        public ClientTransactionController(IClientTransactionBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<ClientTransactionReportRow>> Get(int clientId) => throw new NotImplementedException();

        public ResponseViewModel<ClientTransactionReportRow> Export(int receiptId) => throw new NotImplementedException();

        public ResponseViewModel Post(ClientTransaction transaction) => throw new NotImplementedException();

        public ResponseViewModel Delete(int receiptId) => throw new NotImplementedException();
    }
}