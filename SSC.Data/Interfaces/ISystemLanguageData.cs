using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISystemLanguageData
    {
        string GetKey(string languageCode, string key);
        SystemLanguageEntry GetEntry(int id);
        SystemLanguage GetDictionary(string languageCode);
        void AddNewTranslationKey(string key, string defaultTranslation);
        IEnumerable<SystemLanguage> GetLanguages();
        void UpdateTranslation(SystemLanguageEntry model);
    }
}
