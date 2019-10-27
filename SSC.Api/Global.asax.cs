using SSC.Api.App_Start;
using SSC.Api.Behavior;
using SSC.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace SSC.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InjectionConfig.Register();
            LoggerConfig.Configure();
            GlobalConfiguration.Configuration.Filters.Add(new LogExceptionFilterAttribute());
        }

        protected void Application_PostAuthorizeRequest()
        {
            if (IsWebApiRequest())
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            Logger.Obj.LogException(ex);
        }

        private bool IsWebApiRequest()
        {
            var apiPrefix = "~/api";
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(apiPrefix, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
