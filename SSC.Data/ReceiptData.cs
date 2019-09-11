using DBNostalgia;
using SSC.Common;
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
    public class ReceiptData : IReceiptData
    {
        public ReceiptData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        public Receipt Fetch(IDataReader reader) => throw new NotImplementedException();

        public Receipt GetLastBill(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
