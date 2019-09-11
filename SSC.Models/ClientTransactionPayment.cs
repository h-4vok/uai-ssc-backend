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
    }
}
