using SSC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SSC.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Dependency Resolver
            config.DependencyResolver = DependencyResolver.Obj;

            // Enable CORS globally
            var cors = new EnableCorsAttribute("http://localhost:8000", "*", "*", "*");
            cors.SupportsCredentials = true;
            cors.ExposedHeaders.Add("Set-Cookie");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
