using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Common.Logging;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SampleFunctionBusiness : ISampleFunctionBusiness
    {
        public SampleFunctionBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISampleFunctionData>();
        }
        private ISampleFunctionData data;

        private bool IsForbiddenCode(string code) => new[] { "X", "C", "S" }.Any(x => x == code);

        public void Create(SampleFunction model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            Validator<SampleFunction>.Start(model)
                .MandatoryString(x => x.Code, i10n["global.code"])
                .MandatoryString(x => x.Name, i10n["global.description"])
                .ThrowExceptionIfApplicable();

            if (this.IsForbiddenCode(model.Code))
            {
                throw new UnprocessableEntityException(i10n["sample-function.forbidden-code"]);
            }

            if (!this.data.IsUniqueForClient(model.Code, auth.CurrentClientId, model.Id))
            {
                throw new UnprocessableEntityException(i10n["sample-function.exists"]);
            }

            this.data.Create(model);

            Logger.Obj.LogInfo(String.Format("Función de Muestra - Creada - Código {0}", model.Code));
        }

        public SampleFunction Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<SampleFunction> GetAll()
        {
            return this.data.GetAll();
        }

        public void Update(SampleFunction model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            Validator<SampleFunction>.Start(model)
                .MandatoryString(x => x.Code, i10n["global.code"])
                .MandatoryString(x => x.Name, i10n["global.description"])
                .ThrowExceptionIfApplicable();

            if (this.IsForbiddenCode(model.Code))
            {
                throw new UnprocessableEntityException(i10n["sample-function.forbidden-code"]);
            }

            if (!this.data.IsUniqueForClient(model.Code, auth.CurrentClientId, model.Id))
            {
                throw new UnprocessableEntityException(i10n["sample-function.exists"]);
            }

            this.data.Update(model);
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            this.data.UpdatedIsEnabled(id, isEnabled);
        }
    }
}
