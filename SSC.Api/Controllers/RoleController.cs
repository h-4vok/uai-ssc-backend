﻿using SSC.Api.Behavior;
using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Common.Logging;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class RoleController : ApiController
    {
        private IRoleBusiness business;

        public RoleController(IRoleBusiness business) => this.business = business;

        [HttpGet]
        [SscAuthorize(Permissions = "ROLES_REPORT,ROLES_MANAGEMENT")]
        public ResponseViewModel<IEnumerable<RoleReportRow>> GetAll(string userNameLike, IEnumerable<int> permissionsToHave)
        {
            var output = this.business.GetAll(userNameLike, permissionsToHave);
            return output.ToList();
        }

        [SscAuthorize(Permissions = "ROLES_REPORT,ROLES_MANAGEMENT")]
        public ResponseViewModel<Role> Get(int id)
        {
            var output = this.business.Get(id);
            return output;
        }

        [SscAuthorize(Permissions = "ROLES_MANAGEMENT")]
        public ResponseViewModel Post(Role model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            var validation = Validator<Role>.Start(model)
                .MandatoryString(x => x.Name, i10n["security.role.field.name"])
                .MaxStringLength(x => x.Name, i10n["security.role.field.name"], 300)
                .ListNotEmpty<Permission>(x => x.Permissions, i10n["security.role.field.permissions"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validation))
            {
                return validation;
            }

            this.business.Create(model);
            Logger.Obj.LogInfo(String.Format("El rol '{0}' ha sido creado.", model.Name));

            return true;
        }

        [SscAuthorize(Permissions = "ROLES_MANAGEMENT")]
        public ResponseViewModel Put(int id, Role model)
        {
            var validation = Validator<Role>.Start(model)
                .MandatoryString(x => x.Name, "Nombre")
                .MaxStringLength(x => x.Name, "Nombre", 300)
                .ListNotEmpty<Permission>(x => x.Permissions, "Permisos")
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validation))
            {
                return validation;
            }

            model.Id = id;

            try
            {
                this.business.Update(model);
            }
            catch (UnprocessableEntityException ex)
            {
                return ex.Message;
            }
            
            return true;
        }

        [SscAuthorize(Permissions = "ROLES_MANAGEMENT")]
        public ResponseViewModel Patch(int id, PatchOperationList list)
        {
            foreach(var operation in list.Operations)
            {
                if (operation.op == "replace" && operation.field == "IsEnabled")
                {
                    this.business.UpdateIsEnabled(operation.key, operation.value.AsBool());
                }
            }

            return true;
        }

        [SscAuthorize(Permissions = "ROLES_MANAGEMENT")]
        public ResponseViewModel Delete(int id)
        {
            this.business.Delete(id);
            return true;
        }

        public ResponseViewModel<Role> GetAllPlatform(bool onlyPlatformRoles) => throw new NotImplementedException();
    }
}