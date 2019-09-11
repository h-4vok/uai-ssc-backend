using SSC.Api.ViewModels;
using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class LabScriptController : ApiController
    {
        private IClientCompanyLabScriptBusiness business;

        public LabScriptController(IClientCompanyLabScriptBusiness business) => this.business = business;

        public ResponseViewModel Post(FileUploadViewModel model) => throw new NotImplementedException();
    }
}