using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class CompleteSignUpViewModel
    {
        public User User { get; set; }
        public ClientCompany ClientCompany { get; set; }
    }
}