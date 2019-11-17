using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ReceiptLine
    {
        public int Id { get; set; }
        public string Concept { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal GetTotal()
        {
            return this.Subtotal + this.Taxes;
        }
    }
}
