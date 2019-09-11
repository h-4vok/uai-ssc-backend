using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public int EventTypeId { get; set; }
        public DateTime LoggedDate { get; set; }
        public string UserReference { get; set; }
        public int ClientId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string ErrorSource { get; set; }
        public string ErrorType { get; set; }
    }
}