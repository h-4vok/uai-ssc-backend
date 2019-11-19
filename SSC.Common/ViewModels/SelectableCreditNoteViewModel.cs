using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class SelectableCreditNoteViewModel
    {
        public SelectableCreditNoteViewModel(int id, string number, decimal amount)
        {
            this.CreditNoteNumber = Convert.ToInt32(number).ToString("A0001-0000####");
            this.value = id;
            this.Amount = amount;
            this.FormattedAmount = (-amount).ToString("U$D #.00");
            this.label = String.Format("{0} - {1}", this.CreditNoteNumber, this.FormattedAmount);
        }

        public int value { get; set; }
        public string label { get; set; }
        public decimal Amount { get; set; }
        public string CreditNoteNumber { get; set; }
        public string FormattedAmount { get; set; }
    }
}
