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
    public class ClientMemberController : ApiController
    {
        private IUserBusiness business;

        public ClientMemberController(IUserBusiness business) => this.business = business;

        public IEnumerable<ClientMemberReportRow> GetAll() => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();

        public ResponseViewModel Put(int id, UserController model) => throw new NotImplementedException();

        public ResponseViewModel<User> Get(int id) => throw new NotImplementedException();
    }
}