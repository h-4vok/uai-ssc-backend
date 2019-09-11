using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IClientTransactionData
    {
        IEnumerable<ClientTransactionReportRow> Get(int clientId);
        Receipt GetReceipt(int receiptId);
        string GetNextNumber(int receiptTypeId);
        void Create(ClientTransaction transaction);
        void Nullify(int receiptId);
        bool IsPaid(int receiptId);
    }
}
