﻿using SSC.Api.Behavior;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.App_Start
{
    public static class InjectionConfig
    {
        public static void Register()
        {
            RegisterAll();
            RegisterWebProviders();
            BusinessDependencyInjector.RegisterBusinessDependencies();
        }

        private static void RegisterWebProviders()
        {
            Register<IAuthenticationProvider, AuthenticationProvider>();
            Register<IVerificationCodeHandler, VerificationCodeHandler>();
            Register<ILocalizationProvider, LocalizationProvider>();
            Register<IForgotPasswordTokenCache, ForgotPasswordTokenCache>();
        }

        private static void RegisterAll()
        {
            Register<IEnvironment, SystemEnvironment>();
            Register<IAboutUsBusiness, AboutUsBusiness>();
            Register<IBackupBusiness, BackupBusiness>();
            Register<IClientCompanyBusiness, ClientCompanyBusiness>();
            Register<IClientCompanyLabScriptBusiness, ClientCompanyLabScriptBusiness>();
            Register<IClientTransactionBusiness, ClientTransactionBusiness>();
            Register<IClinicRunBusiness, ClinicRunBusiness>();
            Register<ICreditCardBusiness, CreditCardBusiness>();
            Register<IExternalCreditCardValidator, ExternalCreditCardValidator>();
            Register<ILogBusiness, LogBusiness>();
            Register<IPatientBusiness, PatientBusiness>();
            Register<IPricingPlanBusiness, PricingPlanBusiness>();
            Register<IProvinceBusiness, ProvinceBusiness>();
            Register<IRoleBusiness, RoleBusiness>();
            Register<ISampleBatchBusiness, SampleBatchBusiness>();
            Register<ISampleBusiness, SampleBusiness>();
            Register<ISampleFunctionBusiness, SampleFunctionBusiness>();
            Register<ISampleParameterTypeBusiness, SampleParameterTypeBusiness>();
            Register<ISampleTypeBusiness, SampleTypeBusiness>();
            Register<ISatelliteDataBusiness, SatelliteDataBusiness>();
            Register<ISiteNewsBusiness, SiteNewsBusiness>();
            Register<ISystemLanguageBusiness, SystemLanguageBusiness>();
            Register<IUserBusiness, UserBusiness>();
            Register<IUserInvitationBusiness, UserInvitationBusiness>();
            Register<IWorkOrderBusiness, WorkOrderBusiness>();
            Register<ISmtpHandler, SmtpHandler>();

            Register<IPermissionBusiness, PermissionBusiness>();
            Register<IPricingPlanCommentBusiness, PricingPlanCommentBusiness>();
            Register<IPlatformMenuBusiness, PlatformMenuBusiness>();
            Register<ITranslationKeysBusiness, TranslationKeysBusiness>();
            Register<IFeedbackFormBusiness, FeedbackFormBusiness>();
            Register<ISubmittedFeedbackFormBusiness, SubmittedFeedbackFormBusiness>();
            Register<ISurveyFormBusiness, SurveyFormBusiness>();
            Register<ISubmittedSurveyBusiness, SubmittedSurveyBusiness>();
            Register<ISupportTicketBusiness, SupportTicketBusiness>();
            Register<ISiteNewsCategoryBusiness, SiteNewsCategoryBusiness>();
            Register<IClientManagementBusiness, ClientManagementBusiness>();
            Register<IProductQuestionBusiness, ProductQuestionBusiness>();
        }

        private static void Register<Interface, Concrete>() where Concrete : Interface {
            DependencyResolver.Obj.Register<Interface, Concrete>();
       }
    }
}