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
    public class ProvinceBusiness : IProvinceBusiness
    {
        private IProvinceData data;

        public ProvinceBusiness() => this.data = DependencyResolver.Obj.Resolve<IProvinceData>();

        public IEnumerable<Province> GetAll()
        {
            return this.data.GetAll();
        }
    }
}
