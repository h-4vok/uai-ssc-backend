using DBNostalgia;
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
    public class SiteNewsCategoryData : ISiteNewsCategoryData
    {
        public SiteNewsCategoryData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        public void Create(SiteNewsCategory model)
        {
            this.uow.NonQueryDirect("sp_SiteNewsCategory_create", ParametersBuilder.With("Description", model.Description));
        }

        public void Delete(int id)
        {
            this.uow.NonQueryDirect("sp_SiteNewsCategory_delete", ParametersBuilder.With("Id", id));
        }

        protected SiteNewsCategory Fetch(IDataReader reader) =>
            new SiteNewsCategory
            {
                Id = reader.GetInt32("Id"),
                Description = reader.GetString("Description")
            };

        public SiteNewsCategory Get(int id)
        {
            return this.uow.GetOneDirect("sp_SiteNewsCategory_getOne", this.Fetch, ParametersBuilder.With("Id", id));
        }

        public IEnumerable<SiteNewsCategory> GetAll()
        {
            return this.uow.GetDirect("sp_SiteNewsCategory_get", this.Fetch);
        }

        public void Update(SiteNewsCategory model)
        {
            this.uow.NonQueryDirect("sp_SiteNewsCategory_update",
                ParametersBuilder.With("Id", model.Id)
                    .And("Description", model.Description)
            );
        }

        public bool IsInUse(int id)
        {
            return this.uow.ScalarDirect("sp_SiteNewsCategory_isInUse", ParametersBuilder.With("Id", id)).AsBool();
        }
    }
}
