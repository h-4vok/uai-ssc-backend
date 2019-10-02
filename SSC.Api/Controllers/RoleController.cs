using SSC.Api.Behavior;
using SSC.Business.Interfaces;
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

        public ResponseViewModel Post(Role model) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, Role model) => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();

        public ResponseViewModel Delete(int id) => throw new NotImplementedException();

        public ResponseViewModel<Role> GetAllPlatform(bool onlyPlatformRoles) => throw new NotImplementedException();
    }
}