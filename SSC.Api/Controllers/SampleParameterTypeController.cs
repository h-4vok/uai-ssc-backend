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
    public class SampleParameterTypeController : ApiController
    {
        private ISampleParameterTypeBusiness business;

        public SampleParameterTypeController(ISampleParameterTypeBusiness business) => this.business = business;

        [SscAuthorize(Permissions ="SAMPLE_TYPE_PARAMETERS_MANAGEMENT")]
        public ResponseViewModel<IEnumerable<SampleTypeParameterReportRow>> Get() => this.business.GetAll().ToList();

        [SscAuthorize(Permissions = "SAMPLE_TYPE_PARAMETERS_MANAGEMENT")]
        public ResponseViewModel<SampleTypeParameter> Get(int id) => this.business.Get(id);

        [SscAuthorize(Permissions = "SAMPLE_TYPE_PARAMETERS_MANAGEMENT")]
        public ResponseViewModel Post(SampleTypeParameter model)
        {
            // TODO: validations

            this.business.Create(model);

            return true;
        }

        [SscAuthorize(Permissions = "SAMPLE_TYPE_PARAMETERS_MANAGEMENT")]
        public ResponseViewModel Put(int id, SampleTypeParameter model)
        {
            // TODO: Validations

            model.Id = id;
            this.business.Update(model);

            return true;
        }

        [SscAuthorize(Permissions = "SAMPLE_TYPE_PARAMETERS_MANAGEMENT")]
        public ResponseViewModel Delete(int id)
        {
            // TODO: Validations

            this.business.Delete(id);

            return true;
        }

        [SscAuthorize(Permissions = "SAMPLE_TYPE_PARAMETERS_MANAGEMENT")]
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