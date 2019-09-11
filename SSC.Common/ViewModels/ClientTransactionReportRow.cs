using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ClientTransactionReportRow
    {
        public int ReceiptId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        public decimal Total { get; set; }
        public string TransactionTypeCode { get; set; }
    }
}
