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
    public class SystemLanguageController : ApiController
    {
        private ISystemLanguageBusiness business;

        public SystemLanguageController(ISystemLanguageBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<SystemLanguage>> Get() => throw new NotImplementedException();

        public ResponseViewModel<IEnumerable<SystemLanguageEntry>> Get(int id) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, SystemLanguageEntry model) => throw new NotImplementedException();
    }
}