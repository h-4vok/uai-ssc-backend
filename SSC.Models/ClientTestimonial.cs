using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClientTestimonial
    {
        public int Id { get; set; }
        public string PersonFullName { get; set; }
        public ClientCompany Client { get; set; }
        public string TestimonialText { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
