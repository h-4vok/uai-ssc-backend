using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class NewInvitesViewModel
    {
        public int ClientId { get; set; }
        public IEnumerable<UserInvitation> Invites { get; set; }
    }
}