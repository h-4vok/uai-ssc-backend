using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class BillDetailForReturnViewModel
    {
        public string ReceiptNumber { get; set; }
        public string ItemDescription { get; set; }
        public string TotalAmount { get; set; }
    }
}
