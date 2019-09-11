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
    public class ClinicRunInvalidationController : ApiController
    {
        private IClinicRunBusiness business;

        public ClinicRunInvalidationController(IClinicRunBusiness business) => this.business = business;

        public ResponseViewModel<ClinicRunInvalidation> Get(int id) => throw new NotImplementedException();

        public ResponseViewModel Post(ClinicRunInvalidation model) => throw new NotImplementedException();

        public ResponseViewModel Delete(int id) => throw new NotImplementedException();
    }
}