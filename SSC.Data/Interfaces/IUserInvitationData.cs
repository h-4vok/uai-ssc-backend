using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IUserInvitationData
    {
        void Invite(IEnumerable<UserInvitation> invites);
        bool IsTokenValid(string email, string token);
        string GetClientName(string email, string token);
        void MarkAsUsed(string email, string token);
        void Uninvite(int id);
    }
}
