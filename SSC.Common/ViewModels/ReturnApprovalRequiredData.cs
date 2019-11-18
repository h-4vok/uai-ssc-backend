using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ReturnApprovalRequiredData
    {
        public int ClientId { get; set; }
        public DateTime CurrentExpirationDate { get; set; }
        public int DaysToReturn { get; set; }
        public int ReceiptId { get; set; }
    }
}
