using SSC.Business.Interfaces;
using SSC.Common;
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Patient Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientReportRow> GetAll(int clientId)
        {
            throw new NotImplementedException();
        }

        public bool IsOwnedByClient(int id, int clientId)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient model)
        {
            throw new NotImplementedException();
        }
    }
}
