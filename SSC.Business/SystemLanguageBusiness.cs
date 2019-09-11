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
            throw new NotImplementedException();
        }

        public string GetDictionary(string language)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SystemLanguage> GetLanguages()
        {
            throw new NotImplementedException();
        }

        public string GetTranslation(string language, string key)
        {
            throw new NotImplementedException();
        }

        public void UpdateTranslation(SystemLanguageEntry model)
        {
            throw new NotImplementedException();
        }
    }
}
