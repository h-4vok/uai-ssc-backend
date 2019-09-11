using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IAboutUsData
    {
        IEnumerable<ClientTestimonial> GetLast5();
        Address GetAddress();
    }
}
