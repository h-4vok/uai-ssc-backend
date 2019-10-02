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
    public class UserData : IUserData
    {
        private class UserReportRow
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool IsBlocked { get; set; }
            public bool IsDisabled { get; set; }
            public int LoginFailures { get; set; }
            public DateTime CreatedDate { get; set; }
            public int? CreatedBy { get; set; }
            public DateTime UpdatedDate { get; set; }
            public int? UpdatedBy { get; set; }
            public int? RoleId { get; set; }
            public string RoleName { get; set; }
            public bool? RoleIsPlatformRole { get; set; }
            public int? PermissionId { get; set; }
            public string PermissionCode { get; set; }
            public string PermissionName { get; set; }
        }

        public UserData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private UserReportRow FetchUserGetRecord(IDataReader reader)
        {
            var record = new UserReportRow
            {
                Id = reader.GetInt32("Id"),
                UserName = reader.GetString("UserName"),
                Password = reader.GetString("Password"),
                IsBlocked = reader.GetBoolean("IsBlocked"),
                IsDisabled = reader.GetBoolean("IsDisabled"),
                LoginFailures = reader.GetInt32("LoginFailures"),
                CreatedDate = reader.GetDateTime("CreatedDate"),
                CreatedBy = reader.GetInt32("CreatedBy"),
                UpdatedDate = reader.GetDateTime("UpdatedDate"),
                UpdatedBy = reader.GetInt32("UpdatedBy"),
                RoleId = reader.GetInt32("RoleId"),
                RoleName = reader.GetString("RoleName"),
                RoleIsPlatformRole = reader.GetBoolean("RoleIsPlatformRole"),
                PermissionId = reader.GetInt32Nullable("PermissionId"),
                PermissionCode = reader.GetString("PermissionCode"),
                PermissionName = reader.GetString("PermissionName")
            };

            return record;
        }

        private UserReportViewModel FetchUserReportViewModel(IDataReader reader)
        {
            var record = new UserReportViewModel
            {
                Id = reader.GetInt32("Id"),
                ClientName = reader.GetString("ClientName"),
                UserName = reader.GetString("UserName"),
                IsDisabled = reader.GetBoolean("IsDisabled"),
                IsBlocked = reader.GetBoolean("IsBlocked"),
                CountOfRoles = reader.GetInt32("CountOfRoles"),
                CountOfPermissions = reader.GetInt32("CountOfPermissions"),
                IsPlatformAdmin = reader.GetBoolean("IsPlatformAdmin")
            };

            return record;
        }

        private User ToUser(IEnumerable<UserReportRow> records)
        {
            var firstRecord = records.First();
            var user = new User
            {
                Id = firstRecord.Id,
                UserName = firstRecord.UserName,
                Password = firstRecord.Password,
                IsBlocked = firstRecord.IsBlocked,
                IsDisabled = firstRecord.IsDisabled,
                FirstName = null,
                LastName = null,
                TitleInCompany = null,
                IsEnabledInCompany = true,
                LoginFailures = firstRecord.LoginFailures,
                CreatedDate = firstRecord.CreatedDate,
                CreatedBy = firstRecord.CreatedBy,
                UpdatedDate = firstRecord.UpdatedDate,
                UpdatedBy = firstRecord.UpdatedBy,
            };

            var roles = new List<Role>();
            var currentPermissions = new List<Permission>();
            var currentRole = new Role();

            foreach(var record in records)
            {
                if (!record.RoleId.HasValue) break;

                if (currentRole.Name != record.RoleName)
                {
                    currentRole = new Role
                    {
                        Id = record.RoleId.AsInt(),
                        Name = record.RoleName,
                        IsPlatformRole = record.RoleIsPlatformRole.AsBool(),
                        IsEnabled = true
                    };

                    currentRole.Permissions = currentPermissions = new List<Permission>();
                    roles.Add(currentRole);
                }

                if (!record.PermissionId.HasValue) continue;

                var permission = new Permission
                {
                    Id = record.PermissionId.AsInt(),
                    Code = record.PermissionCode,
                    Name = record.PermissionName,
                };

                currentPermissions.Add(permission);
            }

            user.Roles = roles;

            return user;
        }

        public User Get(string userName)
        {
            var output = uow.Run(() =>
            {
                var userData = 
                    uow.Get("sp_User_getFull", this.FetchUserGetRecord, ParametersBuilder.With("userName", userName));

                var user = this.ToUser(userData);

                return user;
            });

            return output;
        }

        public void RegisterLoginFailure(string userName, int count, bool block)
        {
            uow.NonQueryDirect(
                "sp_User_registerLoginFailure",
                ParametersBuilder.With("userName", userName)
                    .And("count", count)
                    .And("block", block)
                );
        }

        public IEnumerable<UserReportViewModel> GetReport(IEnumerable<int> selectedRoles, IEnumerable<int> selectedPermissions)
        {
            return uow.GetDirect(
                "sp_User_getReport",
                this.FetchUserReportViewModel,
                ParametersBuilder
                    .With("roles", selectedRoles)
                    .And("permissions", selectedPermissions)
                ).ToList();
        }

        public void Create(User model)
        {
            var authProvider = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            int? userId = authProvider.CurrentUserId;
            userId = userId == 0 ? null : userId;

            uow.Run(() =>
            {
                model.Id = uow.Scalar(
                    "sp_User_create",
                    ParametersBuilder.With("userName", model.UserName)
                        .And("password", PasswordHasher.obj.Hash(model.Password))
                        .And("clientCompanyId", model.ClientCompany?.Id)
                        .And("FirstName", model.FirstName)
                        .And("LastName", model.LastName)
                        .And("createdBy", userId)
                        .And("isClientAdmin", !model.Roles.Any())
                    ).AsInt();

                model.Roles.ForEach(role =>
                {
                    uow.NonQuery("sp_UserRole_create",
                        ParametersBuilder
                            .With("userId", model.Id)
                            .And("roleId", role.Id)
                            .And("createdBy", authProvider.CurrentUserId > 0 ? authProvider.CurrentUserId : model.Id)
                        );
                });

                model.Addresses.ForEach(record =>
                {
                    uow.NonQuery("sp_UserAddress_create",
                        ParametersBuilder.With("StreetName", record.StreetName)
                        .And("StreetNumber", record.StreetNumber)
                        .And("City", record.City)
                        .And("PostalCode", record.PostalCode)
                        .And("Department", record.Department)
                        .And("ProvinceId", record.Province.Id)
                        .And("CreatedBy", authProvider.CurrentUserId > 0 ? authProvider.CurrentUserId : model.Id)
                        );
                });
            });
        }

        public bool Exists(string userName)
        {
            return this.uow.ScalarDirect("sp_User_exists", ParametersBuilder.With("userName", userName)).AsBool();
        }

        public bool IsInvited(string userName)
        {
            return this.uow.ScalarDirect("sp_User_IsInvited", ParametersBuilder.With("userName", userName)).AsBool();
        }

        public bool IsEnabled(string userName)
        {
            throw new NotImplementedException();
        }

        public void QueueMailTo(string userName, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public bool CheckTokenValidity(string userName, string token, int daysValid)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(User model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsBlocked(int id, bool isBlocked)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientMemberReportRow> GetClientUsers(int clientId, int currentUserId)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            var output = uow.Run(() =>
            {
                var userData =
                    uow.Get("sp_User_getFull", this.FetchUserGetRecord, ParametersBuilder.With("userId", id));

                var user = this.ToUser(userData);

                return user;
            });

            return output;
        }

        public void UpdateIsClientEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        private ClientMemberReportRow FetchClientMemberReportRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public bool IncreaseLoginFailures(int id)
        {
            var isBlocked = this.uow.ScalarDirect("sp_User_IncreaseLoginFailure", ParametersBuilder.With("id", id)).AsBool();
            return isBlocked;
        }

        private UserSessionViewModel FetchUserSessionViewModel(IDataReader reader)
        {
            var record = new UserSessionViewModel
            {
                UserId = reader.GetInt32("UserId"),
                UserName = reader.GetString("UserName"),
                ClientId = reader.GetInt32("ClientId"),
                ClientApiKey = reader.GetString("ClientApiKey")
            };
            return record;
        }

        public UserSessionViewModel GetSessionViewModel(string userName)
        {
            var output = this.uow.GetOneDirect("sp_User_getSessionData", this.FetchUserSessionViewModel, ParametersBuilder.With("userName", userName));
            return output;
        }
    }
}
