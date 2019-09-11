using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ICreditCardBusiness
    {
        string ValidateData(CreditCard model);
        IEnumerable<CreditCardReportRow> GetAll(int clientId);
        void MakeDefault(int id);
        void Delete(int id);
        void Create(CreditCard model);
        bool IsFromCurrentClient(int id, int clientId);
    }
}
