using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ErrorLog : Log
    {
        public string ErrorType { get; set; }
        public string ErrorSource { get; set; }
        public string ErrorStackTrace { get; set; }
    }
}
