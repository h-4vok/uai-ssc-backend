using DBNostalgia;
using SSC.Common;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class SystemLanguageData : ISystemLanguageData
    {
        public SystemLanguageData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private SystemLanguage Fetch(IDataReader reader) => throw new NotImplementedException();

        private SystemLanguageEntry FetchEntry(IDataReader reader) => throw new NotImplementedException();

        public void AddNewTranslationKey(string key, string defaultTranslation)
        {
            throw new NotImplementedException();
        }

        public string GetDictionary(string languageCode)
        {
            throw new NotImplementedException();
        }

        public string GetKey(string languageCode, string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SystemLanguage> GetLanguages()
        {
            throw new NotImplementedException();
        }

        public void UpdateTranslation(SystemLanguageEntry model)
        {
            throw new NotImplementedException();
        }
    }
}
