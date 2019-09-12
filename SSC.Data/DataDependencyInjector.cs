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

            Register<IAboutUsData, AboutUsData>();
            Register<IBackupData, BackupData>();
            Register<IClientCompanyData, ClientCompanyData>();
            Register<IClientCompanyLabScriptData, ClientCompanyLabScriptData>();
            Register<IClientTransactionData, ClientTransactionData>();
            Register<IClinicRunData, ClinicRunData>();
            Register<ILogData, LogData>();
            Register<IPatientData, PatientData>();
            Register<IPricingPlanData, PricingPlanData>();
            Register<IProvinceData, ProvinceData>();
            Register<IReceiptData, ReceiptData>();
            Register<IRoleData, RoleData>();
            Register<ISampleBatchData, SampleBatchData>();
            Register<ISampleData, SampleData>();
            Register<ISampleFunctionData, SampleFunctionData>();
            Register<ISampleParameterTypeData, SampleParameterTypeData>();
            Register<ISampleTransactionData, SampleTransactionData>();
            Register<ISampleTypeData, SampleTypeData>();
            Register<ISatelliteDataData, SatelliteDataData>();
            Register<ISiteNewsData, SiteNewsData>();
            Register<ISystemLanguageData, SystemLanguageData>();
            Register<IUserData, UserData>();
            Register<IUserInvitationData, UserInvitationData>();
            Register<IWorkOrderData, WorkOrderData>();
        }

        private static void Register<Interface, Concrete>() where Concrete : Interface
        {
            DependencyResolver.Obj.Register<Interface, Concrete>();
        }
    }
}
