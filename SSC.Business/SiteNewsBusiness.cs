﻿using SSC.Business.Interfaces;
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SiteNewsArticle Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SiteNewsArticle> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SiteNewsArticle> GetLatest()
        {
            throw new NotImplementedException();
        }

        public void SendNewsletter(DateTime dateFrom, DateTime dateTo)
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