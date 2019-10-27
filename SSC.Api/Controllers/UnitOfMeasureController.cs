using SSC.Business;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Controllers
{
    public class UnitOfMeasureController : SatelliteDataController<UnitOfMeasure>
    {
        public ResponseViewModel<IEnumerable<UnitOfMeasure>> Get() => this.business.GetUnitOfMeasures().ToList();

        public ResponseViewModel Post(UnitOfMeasure model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validations = Validator<UnitOfMeasure>.Start(model)
                .MandatoryString(x => x.Code, i10n["global.code"])
                .MandatoryString(x => x.DefaultDescription, i10n["global.description"])
                .ValidationResult;

            if (!String.IsNullOrEmpty(validations))
                return validations;

            try
            {
                this.business.Create<UnitOfMeasure>(model);
            }
            catch (UnprocessableEntityException ex)
            {
                return ex.Message;
            }

            return true;
        }

        public ResponseViewModel Patch(int id, PatchOperationList list)
        {
            foreach (var operation in list.Operations)
            {
                if (operation.op == "replace" && operation.field == "IsEnabled")
                {
                    this.business.UpdateIsEnabled<UnitOfMeasure>(operation.key, operation.value.AsBool());
                }
            }

            return true;
        }

    }
}