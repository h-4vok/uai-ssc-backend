using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
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
            var exists = this.data.Exists(model.Name);
            if (exists)
            {
                throw new UnprocessableEntityException("El rol '{0}' ya existe.");
            }

            this.data.Create(model);
        }

        public void Delete(int id)
        {
            this.data.Delete(id);
        }

        public IEnumerable<RoleReportRow> GetAll(string userNameLike, IEnumerable<int> permissionsToHave)
        {
            var output = this.data.GetAll(userNameLike, permissionsToHave);
            return output;
        }

        public void Update(Role model)
        {
            var exists = this.data.Exists(model.Name, model.Id);
            if (exists)
            {
                throw new UnprocessableEntityException("El rol '{0}' ya existe.");
            }

            this.data.Update(model);
        }

        public void UpdateIsEnabled(int id, bool enabled)
        {
            this.data.UpdateIsEnabled(id, enabled);
        }

        public Role Get(int id)
        {
            var item = this.data.Get(id);
            return item;
        }
    }
}
