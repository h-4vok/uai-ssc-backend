using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SupportTicketBusiness : ISupportTicketBusiness
    {
        public SupportTicketBusiness(ISupportTicketData data) => this.data = data;

        protected ISupportTicketData data;

        public SupportTicket GetFullTicket(int id)
        {
            return this.data.GetFullTicket(id);
        }

        public IEnumerable<SupportTicket> GetMyTickets()
        {
            var currentUserId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            return this.data.GetMyTickets(currentUserId);
        }

        public IEnumerable<SupportTicket> GetTickets()
        {
            return this.data.GetTickets();
        }

        public void Reply(SupportTicketConversation message)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<SupportTicketConversation>.Start(message)
                .MandatoryString(x => x.Content, i10n["support-ticket-conversation.model.content"])
                .ThrowExceptionIfApplicable();

            var currentUserId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;
            message.AuthorId = currentUserId;

            this.data.Reply(message);
        }

        public void Start(SupportTicket ticket)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<SupportTicket>.Start(ticket)
                .MandatoryString(x => x.Subject, i10n["support-ticket.model.subject"])
                .MandatoryString(x => x.Status.Code, i10n["support-ticket.model.status-code"])
                .MandatoryString(x => x.Messages.First().Content, i10n["support-ticket.model.content"])
                .ThrowExceptionIfApplicable();

            var currentUserId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;
            ticket.UserId = currentUserId;
            ticket.Messages.ForEach(m => m.AuthorId = currentUserId);

            this.data.Start(ticket);
        }

        public void UpdateStatus(int ticketId, string statusCode)
        {
            this.data.UpdateStatus(ticketId, statusCode);
        }
    }
}
