using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Data;
using SSC.Data.Interfaces;
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
            Register<IAboutUsData, AboutUsData>();
            Register<IBackupData, BackupData>();
            Register<IClientCompanyData, ClientCompanyData>();
            Register<IClientCompanyLabScriptData, ClientCompanyLabScriptData>();
            Register<IClientTransactionData, ClientTransactionData>();
            Register<IClinicRunData, ClinicRunData>();
            Register<ICreditCardData, CreditCardData>();
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

            Register<IPermissionData, PermissionData>();
            Register<IPricingPlanCommentData, PricingPlanCommentData>();

            DataDependencyInjector.RegisterAll();
        }

        private static void Register<Interface, Concrete>() where Concrete : Interface
        {
            DependencyResolver.Obj.Register<Interface, Concrete>();
        }
    }
}
