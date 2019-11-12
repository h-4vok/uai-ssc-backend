using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class NewNewsletterDistributionModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string IncomingHost { get; set; }
    }
}