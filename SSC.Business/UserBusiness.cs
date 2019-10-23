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

        public void SendForgottenPasswordRecovery(string userName, string host)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var exists = this.data.Exists(userName);
            if (!exists)
            {
                throw new UnprocessableEntityException(i10n["forgot-password.validation.user-not-exists"]);
            }

            var enabled = this.data.IsEnabled(userName);
            if (!enabled)
            {
                throw new UnprocessableEntityException(i10n["forgot-password.validation.user-not-enabled"]);
            }

            var recoveryToken = Guid.NewGuid().ToString();
            var forgotPasswordTokenCache = DependencyResolver.Obj.Resolve<IForgotPasswordTokenCache>();
            forgotPasswordTokenCache.Set(recoveryToken, userName);

            {

                var smtp = DependencyResolver.Obj.Resolve<ISmtpHandler>();
                var environment = DependencyResolver.Obj.Resolve<IEnvironment>();

                var mailTemplate = environment.GetEmailTemplate("recover_password_{0}.html");
                var url = String.Format("http://{0}/#/recover-password/{1}/{2}", host, recoveryToken, userName);
                mailTemplate = mailTemplate.Replace("${ResetPasswordLink}", url);

                var mail = new QueuedMail
                {
                    To = userName,
                    Subject = i10n["email.forgot-password.subject"],
                    Body = mailTemplate,
                };

                smtp.Send(mail, true);

                this.data.QueueMailTo(mail.To, mail.Subject, mail.Body);
            }
        }

        public bool IsRecoveryTokenValid(string userName, string token)
        {
            var forgotPasswordTokenCache = DependencyResolver.Obj.Resolve<IForgotPasswordTokenCache>();
            var savedUserForToken = forgotPasswordTokenCache.Get(token);

            var isValid = String.Compare(userName, savedUserForToken, true) == 0;
            return isValid;
        }

        public void UpdatePassword(string userName, string newPassword)
        {
            var hashedPassword = PasswordHasher.obj.Hash(newPassword);

            this.data.UpdatePassword(userName, hashedPassword);
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
            var user = this.data.Get(id);

            // TODO: Evaluate if this currentUserId can access this user id

            return user;
        }

        public void UpdateClientIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public UserSessionViewModel GetSessionViewModel(string userName)
        {
            var output = this.data.GetSessionViewModel(userName);
            return output;
        }
    }
}
