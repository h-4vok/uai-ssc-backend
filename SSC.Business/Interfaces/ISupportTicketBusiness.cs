using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISupportTicketBusiness
    {
        void Start(SupportTicket ticket);
        void Reply(SupportTicketConversation message);
        void UpdateStatus(int ticketId, string statusCode);
        IEnumerable<SupportTicket> GetTickets();
        IEnumerable<SupportTicket> GetMyTickets();
        SupportTicket GetFullTicket(int id);
    }
}
