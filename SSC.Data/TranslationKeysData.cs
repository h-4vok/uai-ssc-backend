using DBNostalgia;
using SSC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class TranslationKeysData : ITranslationKeysData
    {
        public TranslationKeysData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        protected string Fetch(IDataReader reader)
        {
            var item = reader.GetString("TranslationKey");
            return item;
        }

        public IEnumerable<string> GetAll()
        {
            return this.uow.GetDirect("sp_TranslationKeys_getAll", this.Fetch);
        }
    }
}
