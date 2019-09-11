using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClientTransaction
    {
        public int Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Total { get; set; }
        public ClientCompany ClientCompany { get; set; }
        public Receipt Receipt { get; set; }
        public ClientTransactionPayment Payment { get; set; }
        public Receipt RelatedReceipt { get; set; }
    }
}
