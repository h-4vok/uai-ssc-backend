using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Owner { get; set; }
        public int CCV { get; set; }
        public string ExpirationDateMMYY { get; set; }
        public ClientCompany Client { get; set; }
    }
}
