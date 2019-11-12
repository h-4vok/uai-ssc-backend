using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class SupportTicketController : ApiController
    {
        public SupportTicketController(ISupportTicketBusiness business) => this.business = business;

        protected ISupportTicketBusiness business;
        
        public ResponseViewModel<IEnumerable<SupportTicket>> Get(bool onlyMine = false)
        {
            if (onlyMine)
            {
                return this.business.GetMyTickets().ToList();
            }

            return this.business.GetTickets().ToList();
        }

        public ResponseViewModel<SupportTicket> Get(int id) => this.business.GetFullTicket(id);

        public ResponseViewModel Post(SupportTicket ticket) => ResponseViewModel.RunAndReturn(() => this.business.Start(ticket));

        public ResponseViewModel Put(int id, SupportTicketConversation message) => ResponseViewModel.RunAndReturn(() => this.business.Reply(message));

        public ResponseViewModel Patch(int id, PatchOperationList list)
        {
            foreach (var operation in list.Operations)
            {
                if (operation.op == "replace" && operation.field == "StatusCode")
                {
                    this.business.UpdateStatus(operation.key, operation.value);
                }
            }

            return true;
        }
    }
}