using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class BuyViewModel
    {
        public CreditCard CreditCard { get; set; }
        public bool SaveCard { get; set; }
        public IEnumerable<SelectableCreditNoteViewModel> CreditNotes { get; set; } = new List<SelectableCreditNoteViewModel>();
        public string PricingPlanCode { get; set; }
        public bool isAnualBuy { get; set; }
        public string IncomingHost { get; set; }
    }
}
