using SSC.Common;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IUserBusiness
    {
        ResponseViewModel<AuthenticationResponseViewModel> Authenticate(string userName, string password);

        IEnumerable<UserReportViewModel> GetReport(IEnumerable<int> selectedRoles, IEnumerable<int> selectedPermissions);

        void Create(User model);

        string PreValidateNewUser(string userName, string password);

        string ValidateNewUserSignUp(string companyName, string companyTaxCode);

        void SendForgottenPasswordRecovery(string userName, string host);

        bool IsRecoveryTokenValid(string userName, string token);

        void UpdatePassword(string userName, string newPassword);

        void Update(User model);

        void UpdateIsEnabled(int id, bool isEnabled);

        void UpdateIsBlocked(int id, bool isBlocked);

        IEnumerable<ClientMemberReportRow> GetClientUsers(int clientId, int currentUserId);

        User Get(int id, int currentUserId);

        void UpdateClientIsEnabled(int id, bool isEnabled);
        UserSessionViewModel GetSessionViewModel(string userName);
    }
}
