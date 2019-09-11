using SSC.Api.ViewModels;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class UserController : ApiController
    {
        private IUserBusiness business;

        public UserController(IUserBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<UserReportViewModel>> Get(IEnumerable<int> selectedRoles, IEnumerable<int> selectedPermissions) => throw new NotImplementedException();

        public ResponseViewModel Post(User model) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, User model) => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();
    }
}