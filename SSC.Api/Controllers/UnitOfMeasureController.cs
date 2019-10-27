using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Controllers
{
    public class UnitOfMeasureController : SatelliteDataController<UnitOfMeasure>
    {
        public ResponseViewModel<IEnumerable<UnitOfMeasure>> Get() => this.business.GetUnitOfMeasures().ToList();

        public ResponseViewModel Post(UnitOfMeasure model) => throw new NotImplementedException();

        public ResponseViewModel Patch(IEnumerable<PatchOperation> operations) => throw new NotImplementedException();
    }
}