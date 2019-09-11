using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ClientCompanyReportRow
    {
        public int Id { get; set; }
        public string LegalName { get; set; }
        public string TaxCode { get; set; }
        public string SelectedPlanDescription { get; set; }
        public string SelectedPaymentType { get; set; }
        public DateTime LastBillExpirationDate { get; set; }
        public string BalanceStatusDescription { get; set; }
        public bool IsEnabled { get; set; }
    }
}
