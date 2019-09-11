using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ClientBalanceBillReport
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string BilledPlanDescription { get; set; }
        public string BilledPlanFrequency { get; set; }
        public string PaymentMethodDescription { get; set; }
        public decimal Subtotal { get; set; }
        public decimal VAT { get; set; }
        public decimal Total { get; set; }
    }
}
