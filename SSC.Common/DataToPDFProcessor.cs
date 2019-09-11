using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common
{
    public class DataToPDFProcessor<T> : IDataToBlobProcessor<T, byte[]>
    {
        public byte[] BuildOutput(IEnumerable<T> data)
        {
            throw new NotImplementedException();
        }

        public string PrepareForApi(byte[] output)
        {
            throw new NotImplementedException();
        }
    }
}
