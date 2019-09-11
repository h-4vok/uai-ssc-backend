using DBNostalgia;
using SSC.Common;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class PatientData : IPatientData
    {
        public PatientData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private PatientReportRow FetchReportRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private Patient Fetch(IDataReader reader)
        {
            throw new NotImplementedException();
        }

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
