using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClientCompanyBillingInformation
    {
        public int Id { get; set; }
        public string LegalName { get; set; }
        public string TaxCode { get; set; }
        public Address Address { get; set; }
    }
}
