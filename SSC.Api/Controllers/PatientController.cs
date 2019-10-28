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
    public class PatientController : ApiController
    {
        public PatientController(IPatientBusiness business) => this.business = business;

        private IPatientBusiness business;

        public ResponseViewModel<IEnumerable<PatientReportRow>> Get()
        {
            var clientId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentClientId;

            return this.business.GetAll(clientId).ToList();
        }

        public ResponseViewModel<Patient> Get(int id) => this.business.Get(id);

        public ResponseViewModel Post(Patient model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));

        public ResponseViewModel Put(int id, Patient model) => ResponseViewModel.RunAndReturn(() => this.business.Update(model));

        public ResponseViewModel Delete(int id) => ResponseViewModel.RunAndReturn(() => this.business.Delete(id));
    }
}