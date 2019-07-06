using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class SignUpValidationViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TitleInCompany { get; set; }

        public ClientCompanyViewModel CompanyData { get; set; }
        public IEnumerable<PhoneViewModel> PersonalPhones { get; set; }
    }
}