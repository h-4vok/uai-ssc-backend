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
    public class PermissionBusiness : IPermissionBusiness
    {
        private IPermissionData data;

        public PermissionBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IPermissionData>();
        }

        public IEnumerable<Permission> Get()
        {
            var items = this.data.Get();
            return items;
        }
    }
}
