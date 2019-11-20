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

        private SiteNewsCategory FetchCategory(IDataReader reader) =>
            new SiteNewsCategory
            {
                Id = reader.GetInt32("CategoryId"),
                Description = reader.GetString("CategoryDescription")
            };

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

            return this.uow.Run(() =>
            {
                model.Id = this.uow.Scalar("sp_SiteNewsArticle_create",
                    ParametersBuilder.With("Author", model.Author)
                        .And("Title", model.Title)
                        .And("Content", model.Content)
                        .And("PublicationDate", model.PublicationDate)
                        .And("CreatedBy", userId)
                    ).AsInt();

                model.Categories.ForEach(c =>
                {
                    this.uow.NonQuery("sp_SiteNewsArticle_addCategory",
                        ParametersBuilder.With("Id", model.Id)
                            .And("CategoryId", c.Id)
                    );
                });

                return model.Id;
            }, true);
        }

        public void Delete(int id)
        {
            this.uow.NonQueryDirect("sp_SiteNewsArticle_delete", ParametersBuilder.With("Id", id));
        }

        public IEnumerable<SiteNewsArticle> Get()
        {
            return this.uow.GetDirect("sp_SiteNewsArticle_getAll", this.Fetch);
        }

        public IEnumerable<SiteNewsArticle> Get(DateTime dateFrom, DateTime dateTo, IEnumerable<SiteNewsCategory> filterCategories)
        {
            var items = this.uow.GetDirect("sp_SiteNewsArtigle_getBetween",
                this.Fetch,
                ParametersBuilder.With("DateFrom", dateFrom)
                    .And("DateTo", dateTo)
            );

            items.ForEach(m =>
            {
                m.Categories = this.uow.GetDirect("sp_SiteNewsArticle_getCategories", this.FetchCategory,
                    ParametersBuilder.With("Id", m.Id)
                );
            });

            items = items.Where(item => filterCategories.Any(filterC => item.Categories.Any(c => c.Id == filterC.Id)));

            return items;
        }

        public IEnumerable<SiteNewsArticle> GetLatest()
        {
            var items = this.uow.GetDirect("sp_SiteNewsArticle_getLatest",
                this.Fetch,
                ParametersBuilder.With("LatestCount", 3)
            );

            items.ForEach(m =>
            {
                m.Categories = this.uow.GetDirect("sp_SiteNewsArticle_getCategories", this.FetchCategory,
                    ParametersBuilder.With("Id", m.Id)
                );
            });

            return items;
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

        public void SubscribeToNewsletter(string email, IEnumerable<SiteNewsCategory> selectedCategories)
        {
            this.uow.Run(() =>
            {
                var subscriberId = this.uow.Scalar("sp_NewsletterSubscriber_createIfNeeded", ParametersBuilder.With("Email", email));

                this.uow.NonQuery("sp_NewsletterSubscriber_clearCategories", ParametersBuilder.With("Id", subscriberId));

                selectedCategories.ForEach(x =>
                {
                    this.uow.NonQuery("sp_NewsletterSubscriber_addCategory",
                        ParametersBuilder.With("NewsletterSubscriberId", subscriberId)
                        .And("SiteNewsCategoryId", x.Id)
                    );
                });
                
            }, true);
            
        }

        public void UnsubscribeToNewsletter(string email)
        {
            this.uow.NonQueryDirect("sp_NewsletterSubscriber_delete", ParametersBuilder.With("Email", email));
        }

        public void Update(SiteNewsArticle model)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            this.uow.Run(() =>
            {
                this.uow.NonQuery("sp_SiteNewsArticle_update",
                ParametersBuilder.With("Author", model.Author)
                    .And("Id", model.Id)
                    .And("Title", model.Title)
                    .And("Content", model.Content)
                    .And("PublicationDate", model.PublicationDate)
                    .And("UpdatedBy", userId)
                );

                this.uow.NonQuery("sp_SiteNewsArticle_removeCategories", ParametersBuilder.With("Id", model.Id));

                model.Categories.ForEach(c =>
                {
                    this.uow.NonQuery("sp_SiteNewsArticle_addCategory",
                        ParametersBuilder.With("Id", model.Id)
                            .And("CategoryId", c.Id)
                    );
                });

            }, true);
        }

        public SiteNewsArticle Get(int id)
        {
            var item = this.uow.GetOneDirect("sp_SiteNewsArticle_getOne", this.Fetch, ParametersBuilder.With("Id", id));
            item.Categories = this.uow.GetDirect("sp_SiteNewsArticle_getCategories", this.FetchCategory, ParametersBuilder.With("Id", id));

            return item;
        }

        public void SetThumbnail(int id, string filepath, string relativepath)
        {
            this.uow.NonQueryDirect("sp_SiteNewsArticle_setThumbnail",
                ParametersBuilder.With("Id", id)
                    .And("ThumbnailPath", filepath)
                    .And("ThumbnailRelativePath", relativepath)
            );
        }

        public IEnumerable<SiteNewsCategory> GetNewsletterSubscribersCategories(int id, IEnumerable<SiteNewsCategory> filterCategories)
        {
            var categories = this.uow.GetDirect("sp_NewsletterSubscriber_getCategoriesOf", this.FetchCategory, ParametersBuilder.With("NewsletterSubscriberId", id));

            var filtered = filterCategories.Where(f => categories.Any(c => c.Id == f.Id));

            return filtered;
        }
    }
}
