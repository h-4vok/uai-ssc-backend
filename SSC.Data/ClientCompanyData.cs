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
    public class ClientCompanyData : IClientCompanyData
    {
        public ClientCompanyData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        public int Create(ClientCompany model)
        {
            throw new NotImplementedException();
        }

        public void Exists(string name, string taxCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientCompanyReportRow> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClientBalanceReport GetBalanceReport(int id)
        {
            throw new NotImplementedException();
        }

        public ClientCompanyBillingInformation GetBillingInformation(int clientId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBillingInformation(ClientCompanyBillingInformation model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        private ClientCompanyReportRow FetchReportRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private ClientCompanyBillingInformation FetchClientBillingInformation(IDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
