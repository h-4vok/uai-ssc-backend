using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SystemLanguageBusiness : ISystemLanguageBusiness
    {
        public SystemLanguageBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISystemLanguageData>();
        }
        private ISystemLanguageData data;

        public void AddTranslationKey(string key, string defaultTranslation)
        {
            this.data.AddNewTranslationKey(key, defaultTranslation);
        }

        public SystemLanguage GetDictionary(string language)
        {
            return this.data.GetDictionary(language);
        }

        public IEnumerable<SystemLanguage> GetLanguages()
        {
            return this.data.GetLanguages();
        }

        public string GetTranslation(string language, string key)
        {
            return this.data.GetKey(language, key);
        }

        public void UpdateTranslation(SystemLanguageEntry model)
        {
            this.data.UpdateTranslation(model);
        }
    }
}
