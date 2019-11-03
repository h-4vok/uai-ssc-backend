using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class TranslationKeysController : ApiController
    {
        public TranslationKeysController(ITranslationKeysBusiness business) => this.business = business;

        protected ITranslationKeysBusiness business;

        public ResponseViewModel<IEnumerable<string>> Get() => this.business.GetAll().ToList();
    }
}