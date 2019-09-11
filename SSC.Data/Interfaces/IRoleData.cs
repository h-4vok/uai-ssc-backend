using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IRoleData
    {
        IEnumerable<RoleReportRow> GeteAll(string userNameLike, IEnumerable<int> permissionsToHave);
        bool Exists(string roleName, int? currentId = null);
        void Create(Role model);
        void Update(Role model);
        void UpdateIsEnabled(int id, bool isEnabled);
        void Delete(int id);
    }
}
