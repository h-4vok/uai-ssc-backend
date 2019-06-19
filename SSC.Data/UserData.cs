using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
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
            return null;
        }

        private UserReportViewModel FetchUserReportViewModel(IDataReader reader)
        {
            return null;
        }

        private User ToUser(IEnumerable<UserReportRow> records)
        {
            return null;
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
    }
}
