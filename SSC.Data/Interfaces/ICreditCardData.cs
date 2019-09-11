using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ICreditCardData
    {
        void Create(CreditCard model);
        void Delete(int id);
        void SetDefault(int id, int clientId);
        IEnumerable<CreditCardReportRow> GetAll(int clientId);
        bool DoesClientOwnsCreditCard(int id, int clientId);
    }
}
