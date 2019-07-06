using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class ClientCompanyViewModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int ProvinceId { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string Department { get; set; }
        public string PostalCode { get; set; }

        public IEnumerable<PhoneViewModel> Phones { get; set; }
    }
}