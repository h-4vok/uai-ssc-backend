using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IClientManagementData
    {
        ClientLandingViewModel GetLandingData(int clientId);
        PricingPlan GetPricingPlanOfClient(int clientId);
        IEnumerable<SelectableCreditCardViewModel> GetSelectableCreditCards();
        IEnumerable<CreditCard> GetAllCreditCards();
        DateTime GetCurrentServiceExpirationTime(int clientId);
        void UpdateServiceExpirationTime(int clientId, DateTime newDate);
        PrintableBillViewModel GetBillForPrinting(int receiptId);
        bool ReturnForReceiptExists(int receiptId);
        BillDetailForReturnViewModel GetDetailForReturn(int receiptId);
        void StartReturnRequest(int receiptId);
        IEnumerable<ReceiptReturnRequestViewModel> GetReceiptReturnRequests();
        AfterReturnApproval ApproveReturn(int receiptId);
        ReturnApprovalRequiredData GetReturnApprovedRequiredData(int receiptId);
        bool IsPurchaseBill(int receiptId);
        Tuple<int, string> RejectReturn(int receiptId);
    }
}
