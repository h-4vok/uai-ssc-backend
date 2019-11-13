using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class SupportTicketData : ISupportTicketData
    {
        public SupportTicketData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        protected SupportTicket Fetch(IDataReader reader) 
            => new SupportTicket
            {
                Id = reader.GetInt32("Id"),
                UserId = reader.GetInt32("UserId"),
                Subject = reader.GetString("Subject"),
                CreatedDate = reader.GetDateTime("CreatedDate"),
                Status = new SupportTicketStatus
                {
                    Id = reader.GetInt32("StatusId"),
                    Code = reader.GetString("StatusCode"),
                    TranslationKey = reader.GetString("StatusTranslationKey")
                }
            };

        protected SupportTicketConversation FetchConversation(IDataReader reader)
        {
            var record =  new SupportTicketConversation
            {
                Id = reader.GetInt32("Id"),
                AuthorId = reader.GetInt32("AuthorId"),
                AuthorName = reader.GetString("AuthorName"),
                Content = reader.GetString("Content"),
                SupportTicketId = reader.GetInt32("SupportTicketId"),
                IsMine = reader.GetInt32("AuthorId") == DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId,
                CreatedDate = reader.GetDateTime("CreatedDate")
            };

            return record;
        }
            

        public SupportTicket GetFullTicket(int id)
        {
            return this.uow.Run(() =>
            {
                var model = this.uow.GetOne("sp_SupportTicket_getOne", this.Fetch, ParametersBuilder.With("Id", id));

                model.Messages = this.uow.Get("sp_SupportTicketConversation_getByTicket", this.FetchConversation, ParametersBuilder.With("Id", id));

                return model;
            });
        }

        public IEnumerable<SupportTicket> GetMyTickets(int userId)
        {
            return this.uow.GetDirect("sp_SupportTicket_getByUser", this.Fetch, ParametersBuilder.With("UserId", userId));
        }

        public IEnumerable<SupportTicket> GetTickets()
        {
            return this.uow.GetDirect("sp_SupportTicket_getAll", this.Fetch);
        }

        public void Reply(SupportTicketConversation message)
        {
            this.uow.NonQueryDirect("sp_SupportTicketConversation_add",
                ParametersBuilder.With("SupportTicketId", message.SupportTicketId)
                    .And("AuthorId", message.AuthorId)
                    .And("Content", message.Content)
            );
        }

        public void Start(SupportTicket ticket)
        {
            this.uow.Run(() =>
            {
                ticket.Id = this.uow.Scalar("sp_SupportTicket_start",
                    ParametersBuilder.With("StatusCode", ticket.Status.Code)
                        .And("UserId", ticket.UserId)
                        .And("Subject", ticket.Subject)
                ).AsInt();

                ticket.Messages.ForEach(message =>
                {
                    message.SupportTicketId = ticket.Id;

                    this.uow.NonQuery("sp_SupportTicketConversation_add",
                        ParametersBuilder.With("SupportTicketId", message.SupportTicketId)
                            .And("AuthorId", message.AuthorId)
                            .And("Content", message.Content)
                    );
                });

            }, true);
        }

        public void UpdateStatus(int ticketId, string statusCode)
        {
            this.uow.NonQueryDirect("sp_SupportTicket_updateStatus", ParametersBuilder.With("TicketId", ticketId).And("StatusCode", statusCode));
        }
    }
}
