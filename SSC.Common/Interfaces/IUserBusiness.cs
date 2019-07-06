using SSC.Common;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface IUserBusiness
    {
        AuthenticationResponseViewModel Authenticate(string userName, string password);
        IEnumerable<UserReportViewModel> GetReport(IEnumerable<int> selectedRoles, IEnumerable<int> selectedPermissions);
        void Create(User model);
        string ValidateNewUserSignUp(string userName, string password);
    }
}
