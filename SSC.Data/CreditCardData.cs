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
    public class CreditCardData : ICreditCardData
    {
        public CreditCardData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private CreditCardReportRow FetchReportRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public CreditCard Fetch(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void Create(CreditCard model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void SetDefault(int id, int clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreditCardReportRow> GetAll(int clientId)
        {
            throw new NotImplementedException();
        }

        public bool DoesClientOwnsCreditCard(int id, int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
