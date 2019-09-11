﻿using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISiteNewsData
    {
        IEnumerable<SiteNewsArticle> GetLatest();
        IEnumerable<SiteNewsArticle> Get();
        void Create(SiteNewsArticle model);
        void Update(SiteNewsArticle model);
        void Delete(int id);
        void Queue(QueuedMail mail);
        IEnumerable<SiteNewsArticle> Get(DateTime dateFrom, DateTime dateTo);
        IEnumerable<NewsletterSubscriber> GetNewsletterSubscribers();
        bool SubscriberExists(string email);
        void SubscribeToNewsletter(string email);
        void UnsubscribeToNewsletter(string email);
    }
}
