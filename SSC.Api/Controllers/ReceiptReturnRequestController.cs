using SSC.Api.Behavior;
using SSC.Api.ViewModels;
using SSC.Business.Interfaces;
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
    [RoutePrefix("api/receiptreturnrequest")]
    public class ReceiptReturnRequestController : ApiController
    {
        public ReceiptReturnRequestController(IClientManagementBusiness business) => this.business = business;

        protected IClientManagementBusiness business;

        [Route("")]
        [HttpGet]
        public ResponseViewModel<IEnumerable<ReceiptReturnRequestViewModel>> Get() => this.business.GetReceiptReturnRequests().ToList();

        private void SendApprovalMessageToClient(int receiverUserId, string nullifiedReceiptNumber, string creditNoteNumber)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            var message = new ChatMessageViewModel
            {
                AuthorId = auth.CurrentClientId,
                AuthorName = auth.CurrentUserName,
                CreatedDate = DateTime.Now,
                Content = String.Format("Se ha aprobado al devolución sobre la factura {0}. Ahora dispone de la nota de crédito {1} que puede utilizar para comprar servicios en SSC.", nullifiedReceiptNumber, creditNoteNumber),
                IsMine = false
            };

            PlatformChatMessageCache.Add(message, receiverUserId);
        }

        private void SendRejectionMessageToClient(int receiverUserId, string receiptNumber, string rejectionMotive)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            var message = new ChatMessageViewModel
            {
                AuthorId = auth.CurrentClientId,
                AuthorName = auth.CurrentUserName,
                Content = String.Format("Se ha rechazado el pedido de devolución sobre la factura {0}. Detalles sobre la decisión: {1}", receiptNumber, rejectionMotive),
                IsMine = false
            };

            PlatformChatMessageCache.Add(message, receiverUserId);
        }

        [Route("{id}")]
        [HttpPut]
        public ResponseViewModel Put(int id) => ResponseViewModel.RunAndReturn(() => this.business.ApproveReturn(id, this.SendApprovalMessageToClient));

        [Route("")]
        [HttpPost]
        public ResponseViewModel Post(ReturnRejectionViewModel viewModel) => ResponseViewModel.RunAndReturn(() => this.business.RejectReturn(viewModel, this.SendRejectionMessageToClient));
    }
}