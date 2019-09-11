using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class AboutUsViewModel
    {
        public IEnumerable<ClientTestimonial> Testimonials { get; set; }
        public Address OurCompanyAddress { get; set; }
        public string RawSlogan { get; set; }
        public string InfoEmail { get; set; }
    }
}
