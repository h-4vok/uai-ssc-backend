using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IRoleBusiness
    {
        IEnumerable<RoleReportRow> GetAll(string userNameLike, IEnumerable<int> permissionsToHave);
        void Create(Role model);
        void Update(Role model);
        void UpdateIsEnabled(int id, bool enabled);
        void Delete(int id);
    }
}
