using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Behavior
{
    public class LocalizationProvider : ILocalizationProvider
    {
        private ISystemLanguageBusiness business;
        private IAuthenticationProvider authProvider;
        private SystemLanguage currentLanguage = new SystemLanguage { Name = "Not loaded" };
        private IDictionary<string, string> currentDictionary;

        public LocalizationProvider()
        {
            this.business = DependencyResolver.Obj.Resolve<ISystemLanguageBusiness>();
            this.authProvider = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
        }

        private void RefreshDictionary()
        {
            this.currentLanguage = this.business.GetDictionary(this.authProvider.CurrentLanguageCode);
            this.currentDictionary = this.currentLanguage.Entries.ToDictionary(x => x.Key, x => x.Translation);
        }

        public string GetTranslation(string key)
        {
            var languageCode = this.authProvider.CurrentLanguageCode;
            if (this.currentLanguage.Code != languageCode)
            {
                this.RefreshDictionary();
            }

            return this.currentDictionary[key];
        }

        public string this[string key] { get => this.GetTranslation(key); }
    }
}