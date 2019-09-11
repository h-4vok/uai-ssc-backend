using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface IFileSystemProvider
    {
        void SaveTo(string path, byte[] data);
        byte[] ZipPath(string path);
    }
}
