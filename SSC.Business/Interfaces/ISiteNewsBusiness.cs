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
        int Create(SiteNewsArticle model);
        void Update(SiteNewsArticle model);
        void Delete(int id);
        void SendNewsletter(DateTime dateFrom, DateTime dateTo, IEnumerable<SiteNewsCategory> filterCategories, string incomingHost);
        void SubscribeToNewsletter(string email);
        void UnsubscribeToNewsletter(string email);
        void SetThumbnail(int id, string filepath, string relativepath);
    }
}
