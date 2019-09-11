using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISampleData
    {
        IEnumerable<Sample> GetSamples(int clientId, string statusCode, string funcitonCode, string typeCode);
    }
}
