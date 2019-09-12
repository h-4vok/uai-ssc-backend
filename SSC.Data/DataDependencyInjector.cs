using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Injection;

namespace SSC.Data
{
    public static class DataDependencyInjector
    {
        private static void RegisterUnitOfWork()
        {
            var unitOfWorkInjectionFactory = new InjectionFactory(c =>
            {
                IDbConnection connectionBuilder()
                {
                    var environment = DependencyResolver.Obj.Resolve<IEnvironment>();
                    var connection = new SqlConnection(environment.GetPrimaryConnectionString());
                    return connection;
                }

                var unitOfWork = new UnitOfWork(connectionBuilder);
                return unitOfWork;
            });

            DependencyResolver.Obj.Register<IUnitOfWork>(unitOfWorkInjectionFactory);
        }

        public static void RegisterAll()
        {
            RegisterUnitOfWork();
        }
    }
}
