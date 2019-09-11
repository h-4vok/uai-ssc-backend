using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IPatientData
    {
        IEnumerable<PatientReportRow> GetAll(int clientId);
        void Create(Patient model);
        void Update(Patient model);
        void Delete(int id);
        Patient Get(int id);
        bool IsOwnedByClient(int id, int clientId);
    }
}
