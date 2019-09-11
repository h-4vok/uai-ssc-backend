using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class CreditCardReportRow
    {
        public CreditCard CreditCard { get; set; }
        public bool IsDefault { get; set; }
    }
}
