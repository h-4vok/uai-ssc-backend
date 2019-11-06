using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IPlatformMenuBusiness
    {
        IEnumerable<PlatformMenu> GetAll();
        PlatformMenu Get(int id);
        void Create(PlatformMenu menu, IEnumerable<PlatformMenuItem> items);
        void Edit(PlatformMenu menu, IEnumerable<PlatformMenuItem> items);
        void Delete(int id);
        IEnumerable<PlatformMenuItem> GetMenuItems(string searchTerm);
    }
}
