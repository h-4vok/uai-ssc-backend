using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.App_Start
{
    public static class LoggerConfig
    {
        public static void Configure()
        {
            var business = DependencyResolver.Obj.Resolve<ILogBusiness>();
            Logger.Obj.AddSubscriber(business as LoggerSubscriber);
        }
    }
}