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
    public class SiteNewsCategoryController : ApiController
    {
        public SiteNewsCategoryController(ISiteNewsCategoryBusiness business) => this.business = business;

        protected ISiteNewsCategoryBusiness business;

        public ResponseViewModel<IEnumerable<SiteNewsCategory>> Get() => this.business.GetAll().ToList();

        public ResponseViewModel<SiteNewsCategory> Get(int id) => this.business.Get(id);

        public ResponseViewModel Post(SiteNewsCategory model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));

        public ResponseViewModel Put(int id, SiteNewsCategory model) => ResponseViewModel.RunAndReturn(() => this.business.Update(model));

        public ResponseViewModel Delete(int id) => ResponseViewModel.RunAndReturn(() => this.business.Delete(id));
    }
}