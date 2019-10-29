using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class ChangePasswordController : ApiController
    {
        public ChangePasswordController(IUserBusiness business) => this.business = business;

        private IUserBusiness business;

        public ResponseViewModel Post(ChangePasswordViewModel viewModel) {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            if (String.IsNullOrWhiteSpace(viewModel.CurrentPassword)
                || String.IsNullOrWhiteSpace(viewModel.Password1)
                || String.IsNullOrWhiteSpace(viewModel.Password2))
            {
                return i10n["change-password.validation.empty-passwords"];
            }

            if (viewModel.Password1 != viewModel.Password2)
            {
                return i10n["change-password.validation.new-password-no-match"];
            }

            if (!this.business.PasswordMatchesCurrentUser(viewModel.CurrentPassword))
            {
                return i10n["change-password.validation.password-no-match"];
            }

            this.business.UpdatePassword(DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserName, viewModel.Password1);

            var authProvider = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            // Preparar mail de verificacion a este usuario
            var mailTemplatePath = HostingEnvironment.MapPath(String.Format("~/EmailTemplates/password-changed_{0}.html", authProvider.CurrentLanguageCode));
            var mailTemplate = File.ReadAllText(mailTemplatePath);

            mailTemplate = mailTemplate.Replace("${SignInLink}", String.Format("http://{0}/#/sign-in", viewModel.IncomingHost));

            // Enviar mail de verificacion
            var smtpHandler = DependencyResolver.Obj.Resolve<ISmtpHandler>();
            var mail = new QueuedMail
            {
                To = authProvider.CurrentUserName,
                Subject = i10n["email.password-changed.subject"],
                Body = mailTemplate,
            };

            smtpHandler.Send(mail, true);

            return true;
        }
}
}