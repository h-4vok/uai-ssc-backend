﻿using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Controllers
{
    public class PatientTypeController : SatelliteDataController<PatientType>
    {
        public ResponseViewModel<IEnumerable<PatientType>> Get() => this.business.GetPatientTypes().ToList();
    }
}