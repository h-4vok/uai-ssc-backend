using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
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
        private IUserData data;

        public UserBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IUserData>();
        }


        public void Create(User model)
        {
            this.data.Create(model);
        }

        public string ValidateNewUserSignUp(string companyName, string companyTaxCode)
        {
            var companyData = DependencyResolver.Obj.Resolve<IClientCompanyData>();
            var exists = companyData.Exists(companyName, companyTaxCode);

            return exists ? String.Format("La compañía {0} ya existe en la plataforma.", companyName) : String.Empty;
        }

        public string PreValidateNewUser(string userName, string password)
        {
            if (data.Exists(userName))
            {
                return "La cuenta de email ya se encuentra registrada.";
            }

            if (data.IsInvited(userName))
            {
                return "La cuenta de email ya ha sido invitada a la plataforma. Revise su correo electrónico.";
            }

            return String.Empty;
        }

        public ResponseViewModel<AuthenticationResponseViewModel> Authenticate(string userName, string password)
        {
            if (!data.Exists(userName))
            {
                throw UserAuthenticationException.AsUnexistingUserException();
            }

            var user = data.Get(userName);

            if (user.IsDisabled)
            {
                throw UserAuthenticationException.AsDisabledUserException();
            }

            if (user.IsBlocked)
            {
                throw UserAuthenticationException.AsBlockedUserException();
            }

            if (user.Password != PasswordHasher.obj.Hash(password))
            {
                var isBlocked = data.IncreaseLoginFailures(user.Id);

                if (isBlocked)
                {
                    throw UserAuthenticationException.AsBlockedUserException();
                }
                else
                {
                    throw UserAuthenticationException.AsIncorrectPasswordException();
                }
            }

            return new AuthenticationResponseViewModel
            {
                GrantedPermissions = user.GetGrantedPermissions().Select(p => p.Code).ToList(),
            };
        }

        public IEnumerable<UserReportRow> GetReport(IEnumerable<int> selectedRoles, IEnumerable<int> selectedPermissions)
        {
            throw new NotImplementedException();
        }

        public void SendForgottenPasswordRecovery(string userName)
        {
            throw new NotImplementedException();
        }

        public bool IsRecoveryTokenValid(string userName, string token)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(string userName, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void Update(User model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsBlocked(int id, bool isBlocked)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientMemberReportRow> GetClientUsers(int clientId, int currentUserId)
        {
            throw new NotImplementedException();
        }

        public User Get(int id, int currentUserId)
        {
            throw new NotImplementedException();
        }

        public void UpdateClientIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
