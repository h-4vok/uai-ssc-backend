using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class UserInvitationBusiness : IUserInvitationBusiness
    {
        public UserInvitationBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IUserInvitationData>();
            this.userData = DependencyResolver.Obj.Resolve<IUserData>();
        }
        private IUserInvitationData data;
        private IUserData userData;

        public string GetClientName(string email, string token)
        {
            throw new NotImplementedException();
        }

        public void Invite(IEnumerable<UserInvitation> invites)
        {
            throw new NotImplementedException();
        }

        public bool IsTokenValid(string email, string token)
        {
            throw new NotImplementedException();
        }

        public void SignUpFromInvite(UserInvitation invite, string password)
        {
            throw new NotImplementedException();
        }

        public void Uninvite(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
