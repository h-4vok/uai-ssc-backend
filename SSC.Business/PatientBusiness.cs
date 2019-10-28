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
    public class PatientBusiness : IPatientBusiness
    {
        public PatientBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IPatientData>();
        }
        private IPatientData data;

        public void Create(Patient model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<Patient>.Start(model)
                .MandatoryString(x => x.Name, i10n["global.name"])
                .NotNull(x => x.PatientType, i10n["model.patient.patient-type"])
                .MandatoryDropdownSelection(x => x.PatientType.Id, i10n["model.patient.patient-type"])
                .NotNull(x => x.Tenant, i10n["model.patient.client-company"])
                .MandatoryDropdownSelection(x => x.Tenant.Id, i10n["model.patient.client-company"])
                .ThrowExceptionIfApplicable();

            this.data.Create(model);

            Logger.Obj.LogInfo(String.Format("Paciente Creado - {0} - Cliente id: {1}", model.Name, model.Tenant.Id));
        }

        public void Delete(int id)
        {
            var clientId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            if (!this.IsOwnedByClient(id, clientId))
            {
                var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
                throw new UnprocessableEntityException(i10n["model.patient.invalid-delete"]);
            }

            this.data.Delete(id);
        }

        public Patient Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<PatientReportRow> GetAll(int clientId)
        {
            return this.data.GetAll(clientId);
        }

        public bool IsOwnedByClient(int id, int clientId)
        {
            return this.data.IsOwnedByClient(id, clientId);
        }

        public void Update(Patient model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<Patient>.Start(model)
                .MandatoryString(x => x.Name, i10n["global.name"])
                .NotNull(x => x.PatientType, i10n["model.patient.patient-type"])
                .MandatoryDropdownSelection(x => x.PatientType.Id, i10n["model.patient.patient-type"])
                .NotNull(x => x.Tenant, i10n["model.patient.client-company"])
                .MandatoryDropdownSelection(x => x.Tenant.Id, i10n["model.patient.client-company"])
                .ThrowExceptionIfApplicable();

            this.data.Update(model);

            Logger.Obj.LogInfo(String.Format("Paciente Actualizado - {0} - Cliente id: {1}", model.Name, model.Tenant.Id));
        }
    }
}
