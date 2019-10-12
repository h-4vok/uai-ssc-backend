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
    public class SystemLanguageController : ApiController
    {
        private ISystemLanguageBusiness business;

        public SystemLanguageController(ISystemLanguageBusiness business) => this.business = business;

        [SscAuthorize(Permissions = "LANGUAGES_MANAGEMENT")]
        public ResponseViewModel<IEnumerable<SystemLanguage>> Get()
        {
            var output = this.business.GetLanguages();

            return output.ToList();
        }

        public ResponseViewModel<IEnumerable<SystemLanguageEntry>> Get(string code)
        {
            var output = this.business.GetDictionary(code);
            return output.Entries.ToList();
        }

        [SscAuthorize(Permissions = "LANGUAGES_MANAGEMENT")]
        public ResponseViewModel Put(int id, SystemLanguageEntry model)
        {
            model.Id = id;
            this.business.UpdateTranslation(model);

            return true;
        }
    }
}