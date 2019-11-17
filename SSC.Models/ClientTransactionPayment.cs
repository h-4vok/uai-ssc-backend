using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClientTransactionPayment
    {
        public int Id { get; set; }
        public CreditCard CreditCard { get; set; }
        public int? CreditNoteId { get; set; }
        public string Number { get; set; }
        public string Owner { get; set; }
        public int? CCV { get; set; }
        public string ExpirationDateMMYY { get; set; }
        public decimal Amount { get; set; }
    }
}
