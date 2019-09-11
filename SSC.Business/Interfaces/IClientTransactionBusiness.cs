using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IClientTransactionBusiness
    {
        IEnumerable<ClientTransactionReportRow> GetAll(int clientId);
        Receipt GetReceipt(int receiptId);
        void Create(ClientTransaction transaction);
        void Nullify(int receiptId);
    }
}
