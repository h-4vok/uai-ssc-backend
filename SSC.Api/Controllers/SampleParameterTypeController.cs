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

        public ResponseViewModel<IEnumerable<SampleTypeParameterReportRow>> Get() => this.business.GetAll().ToList();

        [SscAuthorize(Permissions = "SAMPLE_TYPE_PARAMETERS_MANAGEMENT")]
        public ResponseViewModel<SampleTypeParameter> Get(int id) => this.business.Get(id);

        [SscAuthorize(Permissions = "SAMPLE_TYPE_PARAMETERS_MANAGEMENT")]
        public ResponseViewModel Post(SampleTypeParameter model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validations = Validator<SampleTypeParameter>.Start(model)
                .MandatoryString(x => x.Code, i10n["global.code"])
                .MandatoryString(x => x.DefaultDescription, i10n["global.description"])
                .NotNull(x => x.DataType, i10n["model.parameter-data-type"])
                .MandatoryDropdownSelection(x => x.DataType.Id, i10n["model.parameter-data-type"])
                .MandatoryDecimal(x => x.MinimumRange, i10n["model.sample-type-parameter.minimum-range"])
                .MandatoryDecimal(x => x.MaximumRange, i10n["model.sample-type-parameter.maximum-range"])
                .NotNull(x => x.UnitOfMeasure, i10n["model.unit-of-measure"])
                .MandatoryDropdownSelection(x => x.UnitOfMeasure.Id, i10n["model.unit-of-measure"])
                .ValidationResult;
               
            if (!String.IsNullOrWhiteSpace(validations))
            {
                return validations;
            }

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
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validations = Validator<SampleTypeParameter>.Start(model)
                .MandatoryString(x => x.Code, i10n["global.code"])
                .MandatoryString(x => x.DefaultDescription, i10n["global.description"])
                .NotNull(x => x.DataType, i10n["model.parameter-data-type"])
                .MandatoryDropdownSelection(x => x.DataType.Id, i10n["model.parameter-data-type"])
                .MandatoryDecimal(x => x.MinimumRange, i10n["model.sample-type-parameter.minimum-range"])
                .MandatoryDecimal(x => x.MaximumRange, i10n["model.sample-type-parameter.maximum-range"])
                .NotNull(x => x.UnitOfMeasure, i10n["model.unit-of-measure"])
                .MandatoryDropdownSelection(x => x.UnitOfMeasure.Id, i10n["model.unit-of-measure"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validations))
            {
                return validations;
            }

            try
            {
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