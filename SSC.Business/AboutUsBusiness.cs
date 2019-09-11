using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class AboutUsBusiness : IAboutUsBusiness
    {
        public AboutUsBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IAboutUsData>();
            this.config = DependencyResolver.Obj.Resolve<IEnvironment>();
        }
        private IAboutUsData data;
        private IEnvironment config;

        public AboutUsViewModel GetAboutUsInformation()
        {
            throw new NotImplementedException();
        }
    }
}
