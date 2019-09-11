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
    public class SiteNewsController : ApiController
    {
        private ISiteNewsBusiness business;

        public SiteNewsController(ISiteNewsBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<SiteNewsArticle>> Get() => throw new NotImplementedException();

        public ResponseViewModel<SiteNewsArticle> Get(int id) => throw new NotImplementedException();

        public ResponseViewModel<IEnumerable<SiteNewsArticle>> Get(bool latest) => throw new NotImplementedException();

        public ResponseViewModel Post(SiteNewsArticle model) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, SiteNewsArticle model) => throw new NotImplementedException();

        public ResponseViewModel Delete(int id) => throw new NotImplementedException();
    }
}