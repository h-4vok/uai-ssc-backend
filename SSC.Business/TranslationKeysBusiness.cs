using SSC.Business.Interfaces;
using SSC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class TranslationKeysBusiness : ITranslationKeysBusiness
    {
        public TranslationKeysBusiness(ITranslationKeysData data) => this.data = data;

        protected ITranslationKeysData data;

        public IEnumerable<string> GetAll()
        {
            return this.data.GetAll();
        }
    }
}
