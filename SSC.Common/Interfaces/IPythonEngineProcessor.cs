using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface IPythonEngineProcessor
    {
        void Run(string scriptPath, int runId, string inputPath, string outputPath);
    }
}
