using SSC.Api.Behavior;
using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class FeedbackFormController : ApiController
    {
        public FeedbackFormController(IFeedbackFormBusiness business) => this.business = business;

        protected IFeedbackFormBusiness business;

        public ResponseViewModel<IEnumerable<FeedbackForm>> Get() => this.business.Get().ToList();

        public ResponseViewModel<FeedbackForm> Get(int id, bool isCurrent) => isCurrent ? this.business.GetCurrent() : this.business.Get(id);

        [SscAuthorize(Permissions = "PLATFORM_ADMIN")]
        public ResponseViewModel Post(FeedbackForm model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));

        [SscAuthorize(Permissions = "PLATFORM_ADMIN")]
        public ResponseViewModel Patch(int id, PatchOperationList list)
        {
            foreach (var operation in list.Operations)
            {
                if (operation.op == "replace" && operation.field == "IsCurrent")
                {
                    this.business.UpdateIsCurrent(operation.key, operation.value.AsBool());
                }
            }

            return true;
        }
    }
}