using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
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
            var record = new SiteNewsArticle
            {
                Id = reader.GetInt32("Id"),
                Author = reader.GetString("Author"),
                Title = reader.GetString("Title"),
                Content = reader.GetString("Content"),
                PublicationDate = reader.GetDateTime("PublicationDate"),
                ThumbnailPath = reader.GetString("ThumbnailPath"),
                ThumbnailRelativePath = reader.GetString("ThumbnailRelativePath")
            };

            return record;
        }

        private NewsletterSubscriber FetchSubscriber(IDataReader reader)
        {
            var record = new NewsletterSubscriber
            {
                Id = reader.GetInt32("Id"),
                Email = reader.GetString("Email"),
                IsEnabled = reader.GetBoolean("IsEnabled")
            };

            return record;
        }

        public int Create(SiteNewsArticle model)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            return this.uow.ScalarDirect("sp_SiteNewsArticle_create",
                ParametersBuilder.With("Author", model.Author)
                    .And("Title", model.Title)
                    .And("Content", model.Content)
                    .And("PublicationDate", model.PublicationDate)
                    .And("CreatedBy", userId)
            ).AsInt();
        }

        public void Delete(int id)
        {
            this.uow.NonQueryDirect("sp_SiteNewsArticle_delete", ParametersBuilder.With("Id", id));
        }

        public IEnumerable<SiteNewsArticle> Get()
        {
            return this.uow.GetDirect("sp_SiteNewsArticle_getAll", this.Fetch);
        }

        public IEnumerable<SiteNewsArticle> Get(DateTime dateFrom, DateTime dateTo)
        {
            return this.uow.GetDirect("sp_SiteNewsArtigle_getBetween",
                this.Fetch,
                ParametersBuilder.With("DateFrom", dateFrom)
                    .And("DateTo", dateTo)
            );
        }

        public IEnumerable<SiteNewsArticle> GetLatest()
        {
            return this.uow.GetDirect("sp_SiteNewsArticle_getLatest",
                this.Fetch,
                ParametersBuilder.With("LatestCount", 3)
            );
        }

        public IEnumerable<NewsletterSubscriber> GetNewsletterSubscribers()
        {
            return this.uow.GetDirect("sp_NewsletterSubscriber_getAll", this.FetchSubscriber);
        }

        public void Queue(QueuedMail mail)
        {
            this.uow.NonQueryDirect("sp_QueuedMail_create",
                ParametersBuilder.With("MailTo", mail.To)
                    .And("Subject", mail.Subject)
                    .And("Body", mail.Body)
            );
        }

        public bool SubscriberExists(string email)
        {
            return this.uow.ScalarDirect("sp_NewsletterSubscriber_exists", ParametersBuilder.With("Email", email)).AsBool();
        }

        public void SubscribeToNewsletter(string email)
        {
            this.uow.NonQueryDirect("sp_NewsletterSubscriber_create", ParametersBuilder.With("Email", email));
        }

        public void UnsubscribeToNewsletter(string email)
        {
            this.uow.NonQueryDirect("sp_NewsletterSubscriber_delete", ParametersBuilder.With("Email", email));
        }

        public void Update(SiteNewsArticle model)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            this.uow.NonQueryDirect("sp_SiteNewsArticle_update",
                ParametersBuilder.With("Author", model.Author)
                    .And("Id", model.Id)
                    .And("Title", model.Title)
                    .And("Content", model.Content)
                    .And("PublicationDate", model.PublicationDate)
                    .And("UpdatedBy", userId)
            );
        }

        public SiteNewsArticle Get(int id)
        {
            return this.uow.GetOneDirect("sp_SiteNewsArticle_getOne", this.Fetch, ParametersBuilder.With("Id", id));
        }

        public void SetThumbnail(int id, string filepath, string relativepath)
        {
            this.uow.NonQueryDirect("sp_SiteNewsArticle_setThumbnail", 
                ParametersBuilder.With("Id", id)
                    .And("ThumbnailPath", filepath)
                    .And("ThumbnailRelativePath", relativepath)
            );
        }
    }
}
