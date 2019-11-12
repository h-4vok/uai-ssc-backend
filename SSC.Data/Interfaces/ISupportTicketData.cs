using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISupportTicketData
    {
        void Start(SupportTicket ticket);
        void Reply(SupportTicketConversation message);
        void UpdateStatus(int ticketId, string statusCode);
        IEnumerable<SupportTicket> GetTickets();
        IEnumerable<SupportTicket> GetMyTickets(int userId);
        SupportTicket GetFullTicket(int id);
    }
}
