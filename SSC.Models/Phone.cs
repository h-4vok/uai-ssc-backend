using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }
    }
}
