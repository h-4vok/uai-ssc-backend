using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SupportTicketConversation
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int SupportTicketId { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public bool IsMine { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
