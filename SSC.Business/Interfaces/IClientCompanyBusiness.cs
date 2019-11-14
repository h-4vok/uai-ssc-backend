using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IClientCompanyBusiness
    {
        int Create(ClientCompany model);
        IEnumerable<ClientCompanyReportRow> GetAll();
        bool IsEnabled(int id);
        void UpdateIsEnabled(int id, bool isEnabled);
        ClientBalanceReport GetBalanceReport(int id);
        ClientCompanyBillingInformation GetBillingInformation(int clientId);
        void UpdateBillingInformation(ClientCompanyBillingInformation model);
    }
}
