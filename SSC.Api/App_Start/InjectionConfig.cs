﻿using SSC.Business;
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
            DependencyResolver.Obj.Register<IEnvironment, SystemEnvironment>();

            DependencyResolver.Obj.Register<IUserBusiness, UserBusiness>();

            BusinessDependencyInjector.RegisterBusinessDependencies();
        }
    }
}