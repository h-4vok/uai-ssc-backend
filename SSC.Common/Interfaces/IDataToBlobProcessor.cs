using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface IDataToBlobProcessor<T, Y>
    {
        Y BuildOutput(IEnumerable<T> data);
    }
}
