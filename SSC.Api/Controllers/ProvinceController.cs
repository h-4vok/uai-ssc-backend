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
    public class ProvinceController : ApiController
    {
        private IProvinceBusiness business;

        public ProvinceController(IProvinceBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<Province>> Get()
        {
            var models = this.business.GetAll();

            return models.ToList();
        }
    }
}