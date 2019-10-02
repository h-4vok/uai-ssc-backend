using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class RoleBusiness : IRoleBusiness
    {
        public RoleBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IRoleData>();
        }
        private IRoleData data;

        public void Create(Role model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleReportRow> GetAll(string userNameLike, IEnumerable<int> permissionsToHave)
        {
            var output = this.data.GeteAll(userNameLike, permissionsToHave);
            return output;
        }

        public void Update(Role model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool enabled)
        {
            throw new NotImplementedException();
        }
    }
}
