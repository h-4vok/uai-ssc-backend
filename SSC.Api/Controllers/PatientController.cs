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
    public class PatientController : ApiController
    {
        public PatientController(IPatientBusiness business) => this.business = business;

        private IPatientBusiness business;

        public ResponseViewModel<PatientReportRow> Get() => throw new NotImplementedException();

        public ResponseViewModel<Patient> Get(int id) => throw new NotImplementedException();

        public ResponseViewModel Post(Patient model) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, Patient model) => throw new NotImplementedException();

        public ResponseViewModel Delete(int id) => throw new NotImplementedException();
    }
}