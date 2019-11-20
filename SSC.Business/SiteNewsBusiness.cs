using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace SSC.Business
{
    public class SiteNewsBusiness : ISiteNewsBusiness
    {
        public SiteNewsBusiness()
        {
            this.uow = DependencyResolver.Obj.Resolve<ISiteNewsData>();
        }
        private ISiteNewsData uow;

        public int Create(SiteNewsArticle model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            {
                var d = model.PublicationDate;
                d = d.Subtract(new TimeSpan(3, 0, 0));
                model.PublicationDate = new DateTime(d.Year, d.Month, d.Day);
            }

            Validator<SiteNewsArticle>.Start(model)
                .MandatoryString(x => x.Author, i10n["site-news.author"])
                .MandatoryString(x => x.Title, i10n["site-news.title"])
                .MandatoryString(x => x.Content, i10n["site-news.content"])
                .ListNotEmpty(x => x.Categories, i10n["site-news.category"])
                .ThrowExceptionIfApplicable();

            return this.uow.Create(model);
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

        public void SendNewsletter(DateTime dateFrom, DateTime dateTo, IEnumerable<SiteNewsCategory> filterCategories, string incomingHost)
        {
            var authProvider = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<string>.Start("")
                .FailWhenClosureReturnsFalse(x => dateFrom <= dateTo, i10n["newsletter.invalid-date-range"])
                .ListNotEmpty(x => filterCategories, i10n["site-news.category"])
                .ThrowExceptionIfApplicable();

            // Build the newsletter for each subscriber
            // Get subscribers
            var subscribers = this.uow.GetNewsletterSubscribers();

            foreach (var subscriber in subscribers)
            {
                // Get the filtered categories by the admin and the subscriber
                var categoriesForThisSubscriber = this.uow.GetNewsletterSubscribersCategories(subscriber.Id, filterCategories);

                if (!categoriesForThisSubscriber.Any())
                    continue;

                // Get the news for these categories and dates
                var news = this.uow.Get(dateFrom, dateTo, categoriesForThisSubscriber);

                // If we have no news for this user, lets get out
                if (!news.Any())
                    continue;

                // Lets build the email and send it to this guy
                {
                    var mailTemplatePath = HostingEnvironment.MapPath(String.Format("~/EmailTemplates/newsletter_{0}.html", authProvider.CurrentLanguageCode));
                    var mailTemplate = File.ReadAllText(mailTemplatePath);
                    var newsTemplatePath = HostingEnvironment.MapPath("~/EmailTemplates/news-article-part.html");
                    var newsTemplate = File.ReadAllText(newsTemplatePath);

                    // Build articles
                    var newsParts = new StringBuilder();

                    news.ForEach(article =>
                    {
                        var part = newsTemplate;
                        part = part.Replace("${PublicationDate}", article.PublicationDate.ToString("yyyy-MM-dd"));
                        part = part.Replace("${Author}", article.Author);
                        part = part.Replace("${Title}", article.Title);
                        part = part.Replace("${Content}", article.Content);

                        var thumbnailBase = ConfigurationManager.AppSettings["SiteNewsImages.ServerBasePath"];
                        var fullThumbnailPath = thumbnailBase + article.ThumbnailRelativePath.Replace("\\", "/");

                        part = part.Replace("${ImageSrc}", fullThumbnailPath);

                        newsParts.Append(part);
                    });

                    // Finish up mail
                    mailTemplate = mailTemplate.Replace("${PlatformLink}", String.Format("http://{0}/#/", incomingHost));
                    mailTemplate = mailTemplate.Replace("${NewsArticles}", newsParts.ToString());

                    // Send email to every subscriber
                    var smtpHandler = DependencyResolver.Obj.Resolve<ISmtpHandler>();

                    var encryptedMail = HttpUtility.UrlEncode(ReversibleEncryption.EncryptString(subscriber.Email));
                    var specificUserMailTemplate = mailTemplate.Replace("${UnsubscribeLink}", String.Format("http://{0}/#/newsletter/unsubscribe/{1}", incomingHost, encryptedMail));

                    var mail = new QueuedMail
                    {
                        To = subscriber.Email,
                        Subject = i10n["newsletter-email.subject"],
                        Body = specificUserMailTemplate,
                    };

                    this.uow.Queue(mail);

                    smtpHandler.Send(mail, true);
                }
            }
        }

        public void SubscribeToNewsletter(string email, IEnumerable<SiteNewsCategory> selectedCategories)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<string>.Start(email)
                .MandatoryString(x => x, i10n["subscribe-newsletter.email"])
                .ValidEmailAddress(x => x, i10n["subscribe-newsletter.email"])
                .ListNotEmpty(x => selectedCategories, i10n["subscribe-newsletter.categories"])
                .ThrowExceptionIfApplicable();

            this.uow.SubscribeToNewsletter(email, selectedCategories);
        }

        public void UnsubscribeToNewsletter(string email)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            String decryptedEmail = String.Empty;

            var validation = Validator<string>.Start(email)
                .MandatoryString(x => x, i10n["subscribe-newsletter.email"])
                .FailWhenClosureReturnsFalse(x =>
                {
                    decryptedEmail = ReversibleEncryption.DecryptString(HttpUtility.UrlDecode(email));

                    var exists = this.uow.SubscriberExists(decryptedEmail);
                    return exists;
                }, i10n["subscribe-newsletter.email-does-not-exist"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validation))
                throw new UnprocessableEntityException(validation);

            this.uow.UnsubscribeToNewsletter(decryptedEmail);
        }

        public void Update(SiteNewsArticle model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            {
                var d = model.PublicationDate;
                d = d.Subtract(new TimeSpan(3, 0, 0));
                model.PublicationDate = new DateTime(d.Year, d.Month, d.Day);
            }

            Validator<SiteNewsArticle>.Start(model)
                .MandatoryString(x => x.Author, i10n["site-news.author"])
                .MandatoryString(x => x.Title, i10n["site-news.title"])
                .MandatoryString(x => x.Content, i10n["site-news.content"])
                .ListNotEmpty(x => x.Categories, i10n["site-news.category"])
                .ThrowExceptionIfApplicable();

            this.uow.Update(model);
        }

        public void SetThumbnail(int id, string filepath, string relativepath)
        {
            this.uow.SetThumbnail(id, filepath, relativepath);
        }
    }
}
