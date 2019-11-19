using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IClientManagementBusiness
    {
        ClientLandingViewModel GetLandingData();
        SelectablePricesViewModel GetSelectablePrices();
        IEnumerable<SelectableCreditCardViewModel> GetSelectableCreditCards();
        void ValidateCreditCard(CreditCard card, bool isPayment);
        void ProcessBuy(BuyViewModel model);
        PrintableBillViewModel GetPrintableBill(int receiptId);
        BillDetailForReturnViewModel GetDetailForReturn(int receiptId);
        void StartReturnRequest(int receiptId);
        IEnumerable<ReceiptReturnRequestViewModel> GetReceiptReturnRequests();
        void ApproveReturn(int receiptId, Action<int, string, string> callback);
        void RejectReturn(ReturnRejectionViewModel viewModel, Action<int, string, string> sendRejectionMessageToClient);
        IEnumerable<SelectableCreditNoteViewModel> GetSelectableCreditNotes();
    }
}
