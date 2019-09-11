using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISiteNewsBusiness
    {
        IEnumerable<SiteNewsArticle> GetLatest();
        IEnumerable<SiteNewsArticle> GetAll();
        SiteNewsArticle Get(int id);
        void Create(SiteNewsArticle model);
        void Update(SiteNewsArticle model);
        void Delete(int id);
        void SendNewsletter(DateTime dateFrom, DateTime dateTo);
        void SubscribeToNewsletter(string email);
        void UnsubscribeToNewsletter(string email);
    }
}
