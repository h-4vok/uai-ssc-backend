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
    public class PermissionController : ApiController
    {
        private readonly IPermissionBusiness business;

        public PermissionController(IPermissionBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<Permission>> Get()
        {
            var items = this.business.Get();
            return items.ToList();
        }
    }
}