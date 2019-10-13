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
    [RoutePrefix("systemLanguage")]
    public class SystemLanguageController : ApiController
    {
        private ISystemLanguageBusiness business;

        public SystemLanguageController(ISystemLanguageBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<SystemLanguageEntry>> Get(int id)
        {
            string code;
            if (id == 1)
            {
                code = "es";
            }
            else
            {
                code = "en";
            }

            var output = this.business.GetDictionary(code);
            return output.Entries.ToList();
        }

        public ResponseViewModel<IEnumerable<SystemLanguage>> Get()
        {
            var output = this.business.GetLanguages();

            return output.ToList();
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