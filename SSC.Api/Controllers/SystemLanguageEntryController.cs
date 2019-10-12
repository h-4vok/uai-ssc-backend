using SSC.Api.Behavior;
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
    public class SystemLanguageEntryController : ApiController
    {
        private ISystemLanguageBusiness business;

        public SystemLanguageEntryController(ISystemLanguageBusiness business) => this.business = business;

        public ResponseViewModel<SystemLanguageEntry> Get(int id)
        {
            return this.business.GetEntry(id);
        }
    }
}