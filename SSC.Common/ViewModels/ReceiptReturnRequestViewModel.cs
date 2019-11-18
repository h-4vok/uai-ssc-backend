using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ReceiptReturnRequestViewModel
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestDate { get; set; }
        public string ReceiptNumber { get; set; }
        public string Status
        {
            get
            {
                if (this.Approved)
                    return "approved";

                if (this.Rejected)
                    return "rejected";

                return "pending";
            }
        }
        public bool Approved { get; set; }
        public string ApprovedBy { get; set; }
        public bool Rejected { get; set; }
        public string RejectedBy { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string RelatedCreditNoteNumber { get; set; }
        public int? RelatedCreditNoteId { get; set; }
    }
}
