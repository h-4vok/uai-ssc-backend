using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class UserChatViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<ChatMessageViewModel> Messages { get; set; } = new List<ChatMessageViewModel>();
        public int PendingCount { get { return this.Messages.Count(x => x.Pending); } }
    }
}