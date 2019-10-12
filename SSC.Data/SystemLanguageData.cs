using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
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

        private readonly IUnitOfWork uow;

        private SystemLanguage Fetch(IDataReader reader)
        {
            var record = new SystemLanguage
            {
                Id = reader.GetInt32("Id"),
                Code = reader.GetString("Code"),
                Name = reader.GetString("Name")
            };
            return record;
        }

        private SystemLanguageEntry FetchEntry(IDataReader reader)
        {
            var record = new SystemLanguageEntry
            {
                Id = reader.GetInt32("Id"),
                Key = reader.GetString("EntryKey"),
                Translation = reader.GetString("Translation")
            };
            return record;
        }

        public void AddNewTranslationKey(string key, string defaultTranslation)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            this.uow.NonQueryDirect("sp_SystemLanguageEntry_new",
                ParametersBuilder.With("key", key)
                .And("defaultTranslation", defaultTranslation)
                .And("createdBy", userId)
                );
        }

        public SystemLanguage GetDictionary(string languageCode)
        {
            var output = this.uow.Run(() =>
            {
                var language = this.uow.GetOne("sp_SystemLanguage_get", this.Fetch, ParametersBuilder.With("code", languageCode));

                language.Entries = this.uow.Get("sp_SystemLanguageEntry_get", this.FetchEntry, ParametersBuilder.With("languageId", language.Id));

                return language;
            });

            return output;
        }

        public string GetKey(string languageCode, string key)
        {
            var output = this.uow.GetOne("sp_SystemLanguageEntry_getOne", this.FetchEntry,
                ParametersBuilder.With("languageCode", languageCode).And("key", key)
                );
            return output?.Translation;
        }

        public IEnumerable<SystemLanguage> GetLanguages()
        {
            var output = this.uow.Run(() =>
            {
                var languages = this.uow.Get("sp_SystemLanguage_getAll", this.Fetch);

                foreach(var language in languages)
                {
                    language.Entries = this.uow.Get("sp_SystemLanguageEntry_get", this.FetchEntry, ParametersBuilder.With("languageId", language.Id));
                }

                return languages;
            });

            return output;
        }

        public void UpdateTranslation(SystemLanguageEntry model)
        {
            this.uow.NonQueryDirect("sp_SystemLanguageEntry_update",
                ParametersBuilder.With("id", model.Id)
                    .And("translation", model.Translation)
            );
        }

        public SystemLanguageEntry GetEntry(int id)
        {
            var output = this.uow.GetOneDirect("sp_SystemLanguage_getEntry", this.FetchEntry, ParametersBuilder.With("id", id));
            return output;
        }
    }
}
