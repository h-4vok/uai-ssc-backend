using SSC.Api.ViewModels;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class UserController : ApiController
    {
        private IUserBusiness business;

        public UserController(IUserBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<UserReportViewModel>> Get(string selectedRoles, string selectedPermissions)
        {
            // TODO: Pending using filters
            var users = this.business.GetReport(null, null);
            return users.ToList();
        }

        public ResponseViewModel<User> Get(int id)
        {
            var authProvider = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            var output = this.business.Get(id, authProvider.CurrentUserId);

            return output;
        }

        public ResponseViewModel Post(User model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validations = Validator<User>.Start(model)
                .MandatoryString(x => x.UserName, i10n["model.user.username"])
                .ValidEmailAddress(x => x.UserName, i10n["model.user.username"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validations))
            {
                return validations;
            }

            try
            {
                this.business.Create(model);
            }
            catch (UnprocessableEntityException ex)
            {
                return ex.Message;
            }

            return true;
        }

        public ResponseViewModel Put(int id, User model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validations = Validator<User>.Start(model)
                .MandatoryString(x => x.UserName, i10n["model.user.username"])
                .ValidEmailAddress(x => x.UserName, i10n["model.user.username"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validations))
            {
                return validations;
            }

            this.business.Update(model);

            return true;
        }

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();
    }
}