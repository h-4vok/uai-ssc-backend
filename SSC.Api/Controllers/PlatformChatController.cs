using SSC.Api.Behavior;
using SSC.Api.ViewModels;
using SSC.Business;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class PlatformChatController : ApiController
    {
        public ResponseViewModel<IEnumerable<ChatMessageViewModel>> Get(int id)
        {
            return PlatformChatMessageCache.Get(id).ToList();
        }

        public ResponseViewModel<IEnumerable<UserChatViewModel>> Get()
        {
            return PlatformChatMessageCache.GetAll().OrderByDescending(x => x.PendingCount).ToList();
        }

        public ResponseViewModel<IEnumerable<ChatMessageViewModel>> Put(int id, ChatMessageViewModel message)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validations = Validator<ChatMessageViewModel>.Start(message)
                .MandatoryString(x => x.Content, i10n["support-ticket-conversation.model.content"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validations))
                return validations;

            message.AuthorId = auth.CurrentUserId;
            message.AuthorName = auth.CurrentUserName;
            message.CreatedDate = DateTime.Now;
            message.IsMine = message.AuthorId == id;

            PlatformChatMessageCache.Add(message, id);

            return this.Get(id);
        }
    }
}