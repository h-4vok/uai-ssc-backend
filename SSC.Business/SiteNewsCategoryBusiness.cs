using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SiteNewsCategoryBusiness : ISiteNewsCategoryBusiness
    {
        public SiteNewsCategoryBusiness(ISiteNewsCategoryData data) => this.data = data;

        protected ISiteNewsCategoryData data;

        public void Create(SiteNewsCategory model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<SiteNewsCategory>.Start(model)
                .MandatoryString(x => x.Description, i10n["global.description"])
                .ThrowExceptionIfApplicable();

            this.data.Create(model);
        }

        public void Delete(int id)
        {
            if (this.data.IsInUse(id))
            {
                var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
                throw new UnprocessableEntityException(i10n["global.cannot-delete-in-use"]);
            }
            this.data.Delete(id);
        }

        public SiteNewsCategory Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<SiteNewsCategory> GetAll()
        {
            return this.data.GetAll();
        }

        public void Update(SiteNewsCategory model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<SiteNewsCategory>.Start(model)
                .MandatoryString(x => x.Description, i10n["global.description"])
                .ThrowExceptionIfApplicable();

            this.data.Update(model);
        }
    }
}
