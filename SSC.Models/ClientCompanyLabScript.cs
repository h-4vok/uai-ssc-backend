using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClientCompanyLabScript
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string FilePath { get; set; }
        public ClientCompany Tenant { get; set; }
    }
}
