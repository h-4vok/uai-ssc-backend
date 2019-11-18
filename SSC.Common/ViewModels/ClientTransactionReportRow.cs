using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ClientTransactionReportRow
    {
        public int TransactionId { get; set; }
        public int ReceiptId { get; set; }
        public string ReceiptNumber { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionDate { get; set; }
        public string Total { get; set; }
        public string TransactionTypeCode { get; set; }
        public string TransactionStatusCode { get; set; } = "finalized";
    }
}
