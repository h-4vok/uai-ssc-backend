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
    public class ProvinceData : IProvinceData
    {
        private IUnitOfWork uow;
        public ProvinceData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        public IEnumerable<Province> GetAll()
        {
            var output = this.uow.GetDirect("sp_Province_getAll", this.Fetch);
            return output;
        }

        private Province Fetch(IDataReader reader)
        {
            var output = new Province
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name")
            };

            return output;
        }
    }
}
