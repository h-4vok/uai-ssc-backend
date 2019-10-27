using SSC.Api.ViewModels;
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
    public class LogController : ApiController
    {
        private ILogBusiness business;

        public LogController(ILogBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<Log>> GetAll() => this.business.GetAll().ToList();

        public ResponseViewModel<Log> Get(int id) => this.business.Get(id);
    }
}