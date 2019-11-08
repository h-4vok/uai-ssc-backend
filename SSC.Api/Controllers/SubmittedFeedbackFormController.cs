using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class SubmittedFeedbackFormController : ApiController
    {
        public SubmittedFeedbackFormController(ISubmittedFeedbackFormBusiness business) => this.business = business;

        protected ISubmittedFeedbackFormBusiness business;

        public ResponseViewModel<IEnumerable<SubmittedFeedbackForm>> Get(bool needForCurrentUser)
        {
            if (needForCurrentUser)
            {
                {
                    var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;
                    var userBusiness = DependencyResolver.Obj.Resolve<IUserBusiness>();
                    var user = userBusiness.Get(userId, userId);

                    var userPermissions = user.GetGrantedPermissions();

                    if (userPermissions.Any(x => x.Code == "PLATFORM_ADMIN"))
                    {
                        return new List<SubmittedFeedbackForm> { new SubmittedFeedbackForm() };
                    }
                }

                var hasOne = this.business.GetHasSubmitted();
                if (hasOne)
                {
                    return new List<SubmittedFeedbackForm> { new SubmittedFeedbackForm() };
                }
                else
                {
                    return new List<SubmittedFeedbackForm>();
                }
            }

            return new List<SubmittedFeedbackForm>();
        }

        public ResponseViewModel Post(SubmittedFeedbackForm model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));
    }
}