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
    public class ClientTransactionBusiness : IClientTransactionBusiness
    {
        public ClientTransactionBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IClientTransactionData>();
        }
        private IClientTransactionData data;

        public void Create(ClientTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientTransactionReportRow> GetAll(int clientId)
        {
            throw new NotImplementedException();
        }

        public Receipt GetReceipt(int receiptId)
        {
            throw new NotImplementedException();
        }

        public void Nullify(int receiptId)
        {
            throw new NotImplementedException();
        }
    }
}
