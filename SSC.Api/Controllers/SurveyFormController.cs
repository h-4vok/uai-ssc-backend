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
    public class SurveyFormController : ApiController
    {
        public SurveyFormController(ISurveyFormBusiness business) => this.business = business;

        protected ISurveyFormBusiness business;

        [SscAuthorize(Permissions = "PLATFORM_ADMIN")]
        public ResponseViewModel Post(SurveyForm model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));

        public ResponseViewModel<SurveyForm> Get(int id) => this.business.Get(id);

        public ResponseViewModel<IEnumerable<SurveyForm>> Get() => this.business.Get().ToList();

        [SscAuthorize(Permissions = "PLATFORM_ADMIN")]
        public ResponseViewModel Patch(int id, PatchOperationList list)
        {
            foreach (var operation in list.Operations)
            {
                if (operation.op == "replace" && operation.field == "IsEnabled")
                {
                    this.business.UpdateIsEnabled(operation.key, operation.value.AsBool());
                }
            }

            return true;
        }
    }
}