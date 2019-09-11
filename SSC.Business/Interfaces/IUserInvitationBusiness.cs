using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IUserInvitationBusiness
    {
        void Invite(IEnumerable<UserInvitation> invites);
        bool UserExists(string email);
        void SignUpFromInvite(UserInvitation invite, string password);
        bool IsTokenValid(string email, string token);
        string GetClientName(string email, string token);
        void Uninvite(int userId);
    }
}
