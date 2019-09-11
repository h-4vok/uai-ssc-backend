using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common
{
    public class FileSystemProvider : IFileSystemProvider
    {
        public void SaveTo(string path, byte[] data)
        {
            throw new NotImplementedException();
        }

        public byte[] ZipPath(string path)
        {
            throw new NotImplementedException();
        }
    }
}
