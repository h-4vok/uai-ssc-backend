using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public abstract class SatelliteDataController<T> : ApiController
    {
        private ISatelliteDataBusiness business;

        public SatelliteDataController() => this.business = DependencyResolver.Obj.Resolve<ISatelliteDataBusiness>();

        public ResponseViewModel<IEnumerable<T>> Get() => throw new NotImplementedException();
    }
}