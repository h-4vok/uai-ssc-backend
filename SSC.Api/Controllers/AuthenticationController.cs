﻿using SSC.Api.ViewModels;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Common.Logging;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace SSC.Api.Controllers
{
    [System.Web.Http.AllowAnonymous]
    [System.Web.Mvc.SessionState(SessionStateBehavior.Required)]
    public class AuthenticationController : ApiController
    {
        private IUserBusiness business;

        public AuthenticationController(IUserBusiness business) => this.business = business;

        public ResponseViewModel<AuthenticationResponseViewModel> Post(AuthenticationViewModel viewModel)
        {
            HttpContext.Current?.Session?.Clear();

            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validations = Validator<AuthenticationViewModel>.Start(viewModel)
                .MandatoryString(x => x.UserName, i10n["model.user.username"])
                .MandatoryString(x => x.Password, i10n["sign-in.password"])
                .ValidationResult;

            if (!String.IsNullOrEmpty(validations))
            {
                Logger.Obj.LogInfo(String.Format("Autenticación Errónea - '{0}' - Error: '{1}'", viewModel.UserName, validations));
                return validations;
            }

            try
            {
                var response = this.business.Authenticate(viewModel.UserName, viewModel.Password);
                var userSessionData = this.business.GetSessionViewModel(viewModel.UserName);

                {
                    var clientBusiness = DependencyResolver.Obj.Resolve<IClientCompanyBusiness>();
                    var isClientEnabled = clientBusiness.IsEnabled(userSessionData.ClientId);

                    if (userSessionData.ClientId > 0 && !isClientEnabled)
                        throw new UserAuthenticationException(i10n["sign-in.validation.client-disabled"]);
                }

                HttpContext.Current.Session["UserName"] = userSessionData.UserName;
                HttpContext.Current.Session["ClientId"] = userSessionData.ClientId;
                HttpContext.Current.Session["UserId"] = userSessionData.UserId;
                HttpContext.Current.Session["Permissions"] = response.Result.GrantedPermissions;
                HttpContext.Current.Session["ClientApiKey"] = userSessionData.ClientApiKey;

                response.Result.SetCookie = String.Format("ASP.NET_SessionId={0}", HttpContext.Current.Session.SessionID);
                response.Result.Menues = this.business.GetMenuForUser(userSessionData.UserId, response.Result.GrantedPermissions);
                response.Result.UserId = userSessionData.UserId;

                Logger.Obj.LogInfo(String.Format("Autenticación Exitosa - '{0}'", userSessionData.UserName));

                return response;
            }
            catch (UserAuthenticationException ex)
            {
                return ex.Message;
            }
        }

        public ResponseViewModel Delete(int id)
        {
            HttpContext.Current?.Session?.Clear();
            return true;
        }
    }
}