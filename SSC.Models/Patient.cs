using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientCompany Tenant { get; set; }
        public PatientType PatientType { get; set; }
    }
}
