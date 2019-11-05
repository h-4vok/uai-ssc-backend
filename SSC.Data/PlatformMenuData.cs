using DBNostalgia;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class PlatformMenuData : IPlatformMenuData
    {
        public PlatformMenuData(IUnitOfWork uow, IAuthenticationProvider auth) {
            this.uow = uow;
            this.auth = auth;
        }

        protected IUnitOfWork uow;
        protected IAuthenticationProvider auth;

        public void Create(PlatformMenu menu, IEnumerable<PlatformMenuItem> items)
        {
            this.uow.Run(() =>
            {
                // Creamos primero el menu
                menu.Id = this.uow.Scalar("sp_PlatformMenu_create",
                    ParametersBuilder.With("Code", menu.Code)
                        .And("TranslationKey", menu.TranslationKey)
                        .And("MenuOrder", menu.MenuOrder)
                        .And("CreatedBy", auth.CurrentUserId)
                ).AsInt();

                // Creamos cada hijo, y por cada hijo agregamos sus permisos
                foreach(var item in items)
                {
                    item.Id = this.uow.Scalar("sp_PlatformMenuItem_create",
                        ParametersBuilder.With("PlatformMenuId", menu.Id)
                            .And("MenuOrder", item.MenuOrder)
                            .And("RelativeRoute", item.RelativeRoute)
                            .And("TranslationKey", item.TranslationKey)
                            .And("CreatedBy", auth.CurrentUserId)
                    ).AsInt();

                    foreach(var requiredPermission in item.RequiredPermissions)
                    {
                        this.uow.NonQuery("sp_PlatformMenuItemPermission_create",
                            ParametersBuilder.With("PlatformMenuItemId", item.Id)
                                .And("PermissionId", requiredPermission.Id)
                                .And("CreatedBy", auth.CurrentUserId)
                        );
                    }

                }

            }, true);
        }

        public void Delete(int id)
        {
            this.uow.NonQueryDirect("sp_PlatformMenu_delete", ParametersBuilder.With("Id", id));
        }

        public void Edit(PlatformMenu menu, IEnumerable<PlatformMenuItem> items)
        {
            this.uow.Run(() =>
            {
                // Actualizamos primero el menu
                this.uow.NonQuery("sp_PlatformMenu_update",
                    ParametersBuilder.With("Code", menu.Code)
                        .And("TranslationKey", menu.TranslationKey)
                        .And("MenuOrder", menu.MenuOrder)
                        .And("Id", menu.Id)
                        .And("UpdatedBy", auth.CurrentUserId)
                );

                // Borramos todos los hijos y sus permisos
                this.uow.NonQuery("sp_PlatformMenu_clean", ParametersBuilder.With("Id", menu.Id));

                // Creamos cada hijo, y por cada hijo agregamos sus permisos
                foreach (var item in items)
                {
                    item.Id = this.uow.Scalar("sp_PlatformMenuItem_create",
                        ParametersBuilder.With("PlatformMenuId", menu.Id)
                            .And("MenuOrder", item.MenuOrder)
                            .And("RelativeRoute", item.RelativeRoute)
                            .And("TranslationKey", item.TranslationKey)
                            .And("CreatedBy", auth.CurrentUserId)
                    ).AsInt();

                    foreach (var requiredPermission in item.RequiredPermissions)
                    {
                        this.uow.NonQuery("sp_PlatformMenuItemPermission_create",
                            ParametersBuilder.With("PlatformMenuItemId", item.Id)
                                .And("PermissionId", requiredPermission.Id)
                                .And("CreatedBy", auth.CurrentUserId)
                        );
                    }

                }

            }, true);
        }

        protected PlatformMenu Fetch(IDataReader reader)
        {
            var record = new PlatformMenu
            {
                Id = reader.GetInt32("Id"),
                Code = reader.GetString("Code"),
                MenuOrder = reader.GetInt32("MenuOrder"),
                TranslationKey = reader.GetString("TranslationKey")
            };

            return record;
        }

        protected PlatformMenuItem FetchItem(IDataReader reader)
        {
            var record = new PlatformMenuItem
            {
                Id = reader.GetInt32("Id"),
                MenuOrder = reader.GetInt32("MenuOrder"),
                RelativeRoute = reader.GetString("RelativeRoute"),
                TranslationKey = reader.GetString("TranslationKey")
            };

            return record;
        }

        protected Permission FetchPermission(IDataReader reader)
        {
            var record = new Permission
            {
                Id = reader.GetInt32("Id"),
                Code = reader.GetString("Code")
            };

            return record;
        }

        public PlatformMenu Get(int id)
        {
            var menu = this.uow.GetOneDirect("sp_PlatformMenu_getOne", this.Fetch, ParametersBuilder.With("Id", id));
            menu.Items = this.uow.GetDirect("sp_PlatformMenuItem_getByParentId", this.FetchItem, ParametersBuilder.With("Id", id)).ToList();

            foreach(var item in menu.Items)
            {
                item.RequiredPermissions = this.uow.GetDirect("sp_PlatformMenuItem_getPermissionsById", this.FetchPermission, 
                    ParametersBuilder.With("MenuItemId", item.Id)
                ).ToList();
            }

            return menu;
        }

        public IEnumerable<PlatformMenu> GetAll()
        {
            return this.uow.GetDirect("sp_PlatformMenu_get", this.Fetch);
        }
    }
}
