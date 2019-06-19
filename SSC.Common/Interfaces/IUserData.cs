using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface IUserData
    {
        User Get(string userName);
        IEnumerable<UserReportViewModel> GetReport(IEnumerable<int> selectedRoles, IEnumerable<int> selectedPermissions);
        void RegisterLoginFailure(string userName, int count, bool block);
    }
}
