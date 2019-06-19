using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
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
            throw new NotImplementedException();
        }

        private void RegisterLoginFailure(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
