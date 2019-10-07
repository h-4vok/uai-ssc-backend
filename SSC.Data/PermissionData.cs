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
    public class PermissionData : IPermissionData
    {
        private IUnitOfWork uow;

        public PermissionData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();    
        }

        public IEnumerable<Permission> Get()
        {
            var items = this.uow.GetDirect("sp_Permission_getAll", this.Fetch);
            return items;
        }

        protected Permission Fetch(IDataReader reader)
        {
            var item = new Permission
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Code = reader.GetString("Code")
            };

            return item;
        }
    }
}
