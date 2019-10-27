using SSC.Api.Behavior;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
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
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            // TODO: validations
            var validations = Validator<SampleTypeParameter>.Start(model)
                .MandatoryString(x => x.Code, i10n["global.code"])
                .MandatoryString(x => x.DefaultDescription, i10n["global.description"])
                .ValidationResult;
               
            try
            {
                this.business.Create(model);
            }
            catch (UnprocessableEntityException ex)
            {
                return ex.Message;
            }

            return true;
        }

        [SscAuthorize(Permissions = "SAMPLE_TYPE_PARAMETERS_MANAGEMENT")]
        public ResponseViewModel Put(int id, SampleTypeParameter model)
        {
            // TODO: Validations

            try
            {
                // Validar que los rangos de numero no afecten datos existentes

                // Validator que los rangos decimales no afected datos existentes

                model.Id = id;
                this.business.Update(model);
            }
            catch (UnprocessableEntityException ex)
            {
                return ex.Message;
            }


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