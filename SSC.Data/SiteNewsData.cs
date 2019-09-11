using DBNostalgia;
using SSC.Common;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class SiteNewsData : ISiteNewsData
    {
        public SiteNewsData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private SiteNewsArticle Fetch(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private NewsletterSubscriber FetchSubscriber(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void Create(SiteNewsArticle model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SiteNewsArticle> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SiteNewsArticle> Get(DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SiteNewsArticle> GetLatest()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NewsletterSubscriber> GetNewsletterSubscribers()
        {
            throw new NotImplementedException();
        }

        public void Queue(QueuedMail mail)
        {
            throw new NotImplementedException();
        }

        public bool SubscriberExists(string email)
        {
            throw new NotImplementedException();
        }

        public void SubscribeToNewsletter(string email)
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeToNewsletter(string email)
        {
            throw new NotImplementedException();
        }

        public void Update(SiteNewsArticle model)
        {
            throw new NotImplementedException();
        }
    }
}
