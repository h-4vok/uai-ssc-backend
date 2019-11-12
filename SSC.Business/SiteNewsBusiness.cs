using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SiteNewsBusiness : ISiteNewsBusiness
    {
        public SiteNewsBusiness()
        {
            this.uow = DependencyResolver.Obj.Resolve<ISiteNewsData>();
        }
        private ISiteNewsData uow;

        public void Create(SiteNewsArticle model)
        {
            this.uow.Create(model);
        }

        public void Delete(int id)
        {
            this.uow.Delete(id);
        }

        public SiteNewsArticle Get(int id)
        {
            return this.uow.Get(id);
        }

        public IEnumerable<SiteNewsArticle> GetAll()
        {
            return this.uow.Get();
        }

        public IEnumerable<SiteNewsArticle> GetLatest()
        {
            return this.uow.GetLatest();
        }

        public void SendNewsletter(DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public void SubscribeToNewsletter(string email)
        {
            this.uow.SubscribeToNewsletter(email);
        }

        public void UnsubscribeToNewsletter(string email)
        {
            this.uow.UnsubscribeToNewsletter(email);
        }

        public void Update(SiteNewsArticle model)
        {
            this.uow.Update(model);
        }
    }
}
