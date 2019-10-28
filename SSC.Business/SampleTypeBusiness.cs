using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Common.Logging;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SampleTypeBusiness : ISampleTypeBusiness
    {
        public SampleTypeBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISampleTypeData>();
            this.languageBusiness = DependencyResolver.Obj.Resolve<ISystemLanguageBusiness>();
        }
        private ISampleTypeData data;
        private ISystemLanguageBusiness languageBusiness;

        public void Create(SampleType model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
            var clientId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            Validator<SampleType>.Start(model)
                .MandatoryString(x => x.Name, i10n["global.name"])
                .ThrowExceptionIfApplicable();


            if (this.data.Exists(model.Name))
            {
                throw new UnprocessableEntityException(i10n["sample-type.validation.exists"]);
            }

            this.data.Create(model);

            Logger.Obj.LogInfo(String.Format("Nuevo Tipo de Muestra Creado - {0} - Cliente Id {1}", model.Name, clientId));
        }

        public void Delete(int id)
        {
            if(this.data.IsUsedOnSamples(id))
            {
                var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

                throw new UnprocessableEntityException(i10n["sample-type.validation.used"]);
            }

            this.data.Delete(id);
        }

        public SampleType Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<SampleTypeReportRow> GetAll()
        {
            var clientId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            return this.data.GetAll(clientId);
        }

        public void Update(SampleType model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
            var clientId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            Validator<SampleType>.Start(model)
                .MandatoryString(x => x.Name, i10n["global.name"])
                .ThrowExceptionIfApplicable();


            if (this.data.Exists(model.Name, model.Id))
            {
                throw new UnprocessableEntityException(i10n["sample-type.validation.exists"]);
            }

            this.data.Update(model);

            Logger.Obj.LogInfo(String.Format("Actualización Tipo de Muestra - {0} - Cliente Id {1}", model.Name, clientId));
        }
    }
}
