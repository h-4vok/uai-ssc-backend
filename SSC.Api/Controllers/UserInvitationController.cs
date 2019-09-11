using SSC.Api.ViewModels;
using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class UserInvitationController : ApiController
    {
        private IUserInvitationBusiness business;

        public UserInvitationController(IUserInvitationBusiness business) => this.business = business;

        public ResponseViewModel Post(NewInvitesViewModel model) => throw new NotImplementedException();

        public ResponseViewModel<bool> Get(string email) => throw new NotImplementedException();

        public ResponseViewModel<UserInvitationSignUpViewModel> Get(string email, string token) => throw new NotImplementedException();

        public ResponseViewModel Put(string token, UserInvitationSignUpViewModel signUp) => throw new NotImplementedException();

        public ResponseViewModel Delete(int id) => throw new NotImplementedException();
    }
}