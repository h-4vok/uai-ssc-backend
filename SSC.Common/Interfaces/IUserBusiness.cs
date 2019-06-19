using SSC.Common;
using SSC.Common.ViewModels;
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
    }
}
