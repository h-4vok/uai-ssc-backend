using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Controllers
{
    public class ParameterDataTypeController : SatelliteDataController<ParameterDataType>
    {
        public ResponseViewModel<IEnumerable<ParameterDataType>> Get() => this.business.GetParameterDataTypes().ToList();
    }
}