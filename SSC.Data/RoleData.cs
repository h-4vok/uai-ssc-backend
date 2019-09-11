using DBNostalgia;
using SSC.Common;
using SSC.Common.ViewModels;
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
    public class RoleData : IRoleData
    {
        public RoleData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private RoleReportRow FetchReportRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void Create(Role model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string roleName, int? currentId = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleReportRow> GeteAll(string userNameLike, IEnumerable<int> permissionsToHave)
        {
            throw new NotImplementedException();
        }

        public void Update(Role model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
