using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class SelectableCreditCardViewModel
    {
        public int value { get; set; }
        public string label { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
