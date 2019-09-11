using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ClientBalanceReport
    {
        public int ClientId { get; set; }
        public string BalanceStatusDescription { get; set; }
        public ClientBalanceBillReport LastBill { get; set; }
    }
}
