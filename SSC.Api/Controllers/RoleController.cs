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

        public ResponseViewModel<RoleReportRow> GetAll(string userNameLike, IEnumerable<int> permissionsToHave) => throw new NotImplementedException();

        public ResponseViewModel Post(Role model) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, Role model) => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();

        public ResponseViewModel Delete(int id) => throw new NotImplementedException();

        public ResponseViewModel<Role> GetAllPlatform(bool onlyPlatformRoles) => throw new NotImplementedException();
    }
}