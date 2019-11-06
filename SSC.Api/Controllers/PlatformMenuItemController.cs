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
    public class PlatformMenuItemController : ApiController
    {
        public PlatformMenuItemController(IPlatformMenuBusiness business) => this.business = business;

        protected IPlatformMenuBusiness business;

        public ResponseViewModel<IEnumerable<PlatformMenuItem>> Get(string searchTerm) => this.business.GetMenuItems(searchTerm).ToList();
    }
}