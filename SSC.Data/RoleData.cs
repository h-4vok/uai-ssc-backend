using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
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
    public class RoleData : IRoleData
    {
        public RoleData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private RoleReportRow FetchReportRow(IDataReader reader)
        {
            var record = new RoleReportRow
            {
                Id = reader.GetInt32("Id"),
                IsEnabled = reader.GetBoolean("IsEnabled"),
                Name = reader.GetString("Name"),
                QuantityOfUsers = reader.GetInt32("QuantityOfUsers"),
                QuantityOfPermissions = reader.GetInt32("QuantityOfPermissions")
            };

            return record;
        }

        public void Create(Role model)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            this.uow.Run(() =>
            {
                model.Id = this.uow.Scalar("sp_Role_create", ParametersBuilder.With("name", model.Name).And("CreatedBy", userId)).AsInt();

                foreach (var permission in model.Permissions)
                {
                    this.uow.NonQuery("sp_RolePermission_add", 
                        ParametersBuilder.With("roleId", model.Id)
                            .And("permissionId", permission.Id)
                            .And("createdBy", userId));
                }
            }, true);
        }

        public void Delete(int id)
        {
            this.uow.Run(() =>
            {
                this.uow.NonQuery("sp_RolePermission_delete", ParametersBuilder.With("roleId", id));
                this.uow.NonQuery("sp_Role_delete", ParametersBuilder.With("id", id));
            }, true);
        }

        public bool Exists(string roleName, int? currentId = null)
        {
            var output = this.uow.ScalarDirect("sp_Role_exists", ParametersBuilder.With("name", roleName).And("currentId", currentId)).AsBool();
            return output;
        }

        public IEnumerable<RoleReportRow> GetAll(string userNameLike, IEnumerable<int> permissionsToHave)
        {
            var output = this.uow.GetDirect("sp_Role_getAll", this.FetchReportRow);
            return output;
        }

        public void Update(Role model)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            this.uow.Run(() =>
            {
                this.uow.NonQuery("sp_Role_update", ParametersBuilder.With("id", model.Id).And("name", model.Name).And("updatedBy", userId));

                this.uow.NonQuery("sp_RolePermission_delete", ParametersBuilder.With("roleId", model.Id));

                foreach (var permission in model.Permissions)
                {
                    this.uow.NonQuery("sp_RolePermission_add", ParametersBuilder.With("roleId", model.Id).And("permissionId", permission.Id));
                }
            }, true);
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            this.uow.NonQueryDirect("sp_Role_updateIsEnabled", ParametersBuilder.With("id", id).And("IsEnabled", isEnabled));
        }

        private Role Fetch(IDataReader reader)
        {
            var record = new Role
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                IsEnabled = reader.GetBoolean("IsEnabled"),
                IsPlatformRole = reader.GetBoolean("IsPlatformRole"),
                CreatedBy = reader.GetInt32Nullable("CreatedBy"),
                UpdatedBy = reader.GetInt32Nullable("UpdatedBy"),
                CreatedDate = reader.GetDateTime("CreatedDate"),
                UpdatedDate = reader.GetDateTime("UpdatedDate")
            };

            return record;
        }

        private Permission FetchPermission(IDataReader reader)
        {
            var record = new Permission
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Code = reader.GetString("Code"),
                CreatedBy = reader.GetInt32Nullable("CreatedBy"),
                UpdatedBy = reader.GetInt32Nullable("UpdatedBy"),
                CreatedDate = reader.GetDateTime("CreatedDate"),
                UpdatedDate = reader.GetDateTime("UpdatedDate")
            };

            return record;
        }

        public Role Get(int id)
        {
            var role = this.uow.Run(() =>
            {
                var item = this.uow.GetOne("sp_Role_get", this.Fetch, ParametersBuilder.With("id", id));

                item.Permissions = this.uow.Get("sp_Role_getPermissions", this.FetchPermission, ParametersBuilder.With("roleId", id));

                return item;
            });

            return role;
        }
    }
}
