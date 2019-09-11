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
    public class ClientTransactionData : IClientTransactionData
    {
        public ClientTransactionData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        public ClientTransactionReportRow FetchReportRow(IDataReader reader) => throw new NotImplementedException();

        private Receipt FetchReceipt(IDataReader reader) => throw new NotImplementedException();

        public void Create(ClientTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientTransactionReportRow> Get(int clientId)
        {
            throw new NotImplementedException();
        }

        public string GetNextNumber(int receiptTypeId)
        {
            throw new NotImplementedException();
        }

        public Receipt GetReceipt(int receiptId)
        {
            throw new NotImplementedException();
        }

        public bool IsPaid(int receiptId)
        {
            throw new NotImplementedException();
        }

        public void Nullify(int receiptId)
        {
            throw new NotImplementedException();
        }
    }
}
