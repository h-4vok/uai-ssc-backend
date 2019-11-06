using SSC.Business.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class PlatformMenuBusiness : IPlatformMenuBusiness
    {
        public PlatformMenuBusiness(IPlatformMenuData data) => this.data = data;

        protected IPlatformMenuData data;

        public void Create(PlatformMenu menu, IEnumerable<PlatformMenuItem> items)
        {
            this.data.Create(menu, items);
        }

        public void Delete(int id)
        {
            this.data.Delete(id);
        }

        public void Edit(PlatformMenu menu, IEnumerable<PlatformMenuItem> items)
        {
            this.data.Edit(menu, items);
        }

        public PlatformMenu Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<PlatformMenu> GetAll()
        {
            return this.data.GetAll();
        }

        public IEnumerable<PlatformMenuItem> GetMenuItems(string searchTerm)
        {
            return this.data.GetMenuItems(searchTerm);
        }
    }
}
