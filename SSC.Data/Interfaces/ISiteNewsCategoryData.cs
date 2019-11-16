using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISiteNewsCategoryData
    {
        void Create(SiteNewsCategory model);
        void Update(SiteNewsCategory model);
        void Delete(int id);
        IEnumerable<SiteNewsCategory> GetAll();
        SiteNewsCategory Get(int id);
        bool IsInUse(int id);
    }
}
