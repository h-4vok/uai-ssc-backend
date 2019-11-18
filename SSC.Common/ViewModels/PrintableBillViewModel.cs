using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class PrintableBillViewModel
    {
        public string ReceiptNumber { get; set; }
        public string FormattedTransactionDate { get; set; }
        public string ClientLegalName { get; set; }
        public string ClientCompositeAddress { get; set; }
        public string ClientTaxCode { get; set; }
        public bool IsCreditCardSale { get; set; }
        public bool IsCreditNoteSale { get; set; }
        public IList<PrintableBillLineViewModel> Lines { get; set; } = new List<PrintableBillLineViewModel>();
        public string FormattedSubtotal { get; set; }
        public string FormattedVAT { get; set; }
        public string FormattedTotal { get; set; }
    }

    public class PrintableBillLineViewModel
    {
        public int Quantity { get; set; }
        public string Detail { get; set; }
        public string FormattedUnitPrice { get; set; }
        public string FormattedTotalPrice { get; set; }
    }
}
