using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class RawDataController : ApiController
    {
        private IClinicRunBusiness business;

        public RawDataController(IClinicRunBusiness business) => this.business = business;

        public ResponseViewModel<byte[]> Get(int id) => throw new NotImplementedException();
    }
}