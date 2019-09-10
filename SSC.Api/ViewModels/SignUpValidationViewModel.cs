﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public enum SignUpValidationStep
    {
        Initial,
        Company,
        Pricing,
        Billing,
        Payment
    }

    public class SignUpValidationViewModel
    {
        public SignUpValidationStep Step { get; set; } = SignUpValidationStep.Initial;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string TitleInCompany { get; set; }

        public ClientCompanyViewModel CompanyData { get; set; }
        public IEnumerable<PhoneViewModel> PersonalPhones { get; set; }
    }
}