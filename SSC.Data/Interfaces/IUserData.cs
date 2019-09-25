using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IUserData
    {
        User Get(string userName);
        IEnumerable<UserReportViewModel> GetReport(IEnumerable<int> selectedRoles, IEnumerable<int> selectedPermissions);
        void RegisterLoginFailure(string userName, int count, bool block);
        void Create(User model);
        bool Exists(string userName);
        bool IsInvited(string userName);
        bool IsEnabled(string userName);
        void QueueMailTo(string userName, string subject, string body);
        bool CheckTokenValidity(string userName, string token, int daysValid);
        void UpdatePassword(string userName, string password);
        void Update(User model);
        void UpdateIsEnabled(int id, bool isEnabled);
        void UpdateIsBlocked(int id, bool isBlocked);
        IEnumerable<ClientMemberReportRow> GetClientUsers(int clientId, int currentUserId);
        User Get(int id);
        void UpdateIsClientEnabled(int id, bool isEnabled);
        bool IncreaseLoginFailures(int id);
    }
}
