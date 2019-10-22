using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Interfaces
{
    public interface ILocalizationProvider
    {
        string GetTranslation(string key);

        string this[string key] { get; }
    }
}
