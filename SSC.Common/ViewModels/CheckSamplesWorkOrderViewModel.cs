﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class CheckSamplesWorkOrderViewModel
    {
        public IEnumerable<CheckableSampleReportRow> CheckedSamples { get; set; }
    }
}
