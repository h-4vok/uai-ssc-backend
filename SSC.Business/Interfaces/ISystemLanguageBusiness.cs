using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISystemLanguageBusiness
    {
        string GetTranslation(string language, string key);
        string GetDictionary(string language);
        void AddTranslationKey(string key, string defaultTranslation);
        IEnumerable<SystemLanguage> GetLanguages();
        void UpdateTranslation(SystemLanguageEntry model);
    }
}
