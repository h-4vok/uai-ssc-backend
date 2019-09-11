using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class BillingController : ApiController
    {
        private IBillBusiness business;

        public BillingController(IBillBusiness business) => this.business = business;

        public ResponseViewModel<object> GetLast(int id) => throw new NotImplementedException();
    }
}