using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SSC.Api.Behavior
{
    public class SscAuthorize : AuthorizeAttribute
    {
        public string Permissions { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (String.IsNullOrWhiteSpace(this.Permissions)) return true;

            var authorizationProvider = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var userId = authorizationProvider.CurrentUserId;

            if (userId == 0)
            {
                this.TrySetResponse(actionContext, new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized));
                return false;
            }

            var userBusiness = DependencyResolver.Obj.Resolve<IUserBusiness>();
            var user = userBusiness.Get(userId, userId);

            var requiredPermissions = this.Permissions.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var userPermissions = user.GetGrantedPermissions();

            var hasAnyRequiredPermissions =
                requiredPermissions
                .Any(requiredPermissionCode =>
                    userPermissions.Any(userPermission => userPermission.Code == requiredPermissionCode));

            if (!hasAnyRequiredPermissions)
            {
                this.TrySetResponse(actionContext, new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden));
                return false;
            }

            return true;
        }

        private void TrySetResponse(HttpActionContext actionContext, HttpResponseMessage message)
        {
            try
            {
                actionContext.Response = message;
            }
            catch
            {
                // Catch for some devs who had issues with actionContext.Response
            }
        }
    }
}