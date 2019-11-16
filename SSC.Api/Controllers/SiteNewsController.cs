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

        public ResponseViewModel<IEnumerable<SiteNewsArticle>> Get(bool latest = false) =>  latest ? this.business.GetLatest().ToList() : this.business.GetAll().ToList();

        public ResponseViewModel<SiteNewsArticle> Get(int id) => this.business.Get(id);

        public ResponseViewModel<int> Post(SiteNewsArticle model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));

        public ResponseViewModel Put(int id, SiteNewsArticle model) => ResponseViewModel.RunAndReturn(() => this.business.Update(model));

        public ResponseViewModel Delete(int id) => ResponseViewModel.RunAndReturn(() => this.business.Delete(id));
    }
}