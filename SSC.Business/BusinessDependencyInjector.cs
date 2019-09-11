using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public static class BusinessDependencyInjector
    {
        public static void RegisterBusinessDependencies()
        {
            DependencyResolver.Obj.Register<IUserData, UserData>();

            DataDependencyInjector.Register();
        }
    }
}
