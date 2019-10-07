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
        IEnumerable<RoleReportRow> GetAll(string userNameLike, IEnumerable<int> permissionsToHave);

        Role Get(int id);
        bool Exists(string roleName, int? currentId = null);
        void Create(Role model);
        void Update(Role model);
        void UpdateIsEnabled(int id, bool isEnabled);
        void Delete(int id);
    }
}
