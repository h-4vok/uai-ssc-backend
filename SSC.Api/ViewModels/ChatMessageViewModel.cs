using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class ChatMessageViewModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public bool IsMine { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Pending { get; set; } = true;
    }
}