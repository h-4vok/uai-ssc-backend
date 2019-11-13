using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }
        public SupportTicketStatus Status { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<SupportTicketConversation> Messages { get; set; }
    }
}
