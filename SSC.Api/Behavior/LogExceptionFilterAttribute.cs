using SSC.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace SSC.Api.Behavior
{
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Logger.Obj.LogException(actionExecutedContext.Exception);
        }
    }
}