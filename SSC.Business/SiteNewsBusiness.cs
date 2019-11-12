using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void SendNewsletter(DateTime dateFrom, DateTime dateTo, string incomingHost)
        {
            var authProvider = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            // Setup templates
            var news = this.uow.Get(dateFrom, dateTo);

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

                newsParts.Append(part);
            });

            // Finish up mail
            mailTemplate = mailTemplate.Replace("${PlatformLink}", String.Format("http://{0}/#/", incomingHost));
            mailTemplate = mailTemplate.Replace("${UnsubscribeLink}", String.Format("http://{0}/#/newsletter/unsubscribe", incomingHost));
            mailTemplate = mailTemplate.Replace("${NewsArticles}", newsParts.ToString());

            // Get subscribers
            var subscribers = this.uow.GetNewsletterSubscribers();

            // Send email to every subscriber
            var smtpHandler = DependencyResolver.Obj.Resolve<ISmtpHandler>();

            subscribers.ForEach(subscriber =>
            {
                var mail = new QueuedMail
                {
                    To = authProvider.CurrentUserName,
                    Subject = i10n["newsletter-email.subject"],
                    Body = mailTemplate,
                };

                smtpHandler.Send(mail, true);
            });
        }

        public void SubscribeToNewsletter(string email)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validation = Validator<string>.Start(email)
                .MandatoryString(x => x, i10n["subscribe-newsletter.email"])
                .ValidEmailAddress(x => x, i10n["subscribe-newsletter.email"])
                .FailWhenClosureReturnsFalse(x =>
                {
                    var exists = this.uow.SubscriberExists(x);
                    return !exists;
                }, i10n["subscribe-newsletter.email-exists"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validation))
                throw new UnprocessableEntityException(validation);

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
