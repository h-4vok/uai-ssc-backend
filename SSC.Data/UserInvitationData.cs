using DBNostalgia;
using SSC.Common;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class UserInvitationData : IUserInvitationData
    {
        public UserInvitationData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

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

        public void MarkAsUsed(string email, string token)
        {
            throw new NotImplementedException();
        }

        public void Uninvite(int id)
        {
            throw new NotImplementedException();
        }
    }
}
