﻿using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class UserBusiness : IUserBusiness
    {
        public AuthenticationResponseViewModel Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserReportViewModel> GetReport(IEnumerable<int> selectedRoles, IEnumerable<int> selectedPermissions)
        {
            var data = DependencyResolver.Obj.Resolve<IUserData>();
            throw new NotImplementedException();
        }

        private void RegisterLoginFailure(string userName)
        {
            throw new NotImplementedException();
        }

        public void Create(User model)
        {
            var data = DependencyResolver.Obj.Resolve<IUserData>();
            throw new NotImplementedException();
        }

        public string ValidateNewUserSignUp(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}