using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ClinicRunReportRow
    {
        public int Id { get; set; }
        public string StageDescription { get; set; }
        public string StatusDescription { get; set; }
        public int QuantityOfSamples { get; set; }
        public int QuantityOfExecutions { get; set; }
        public int QuantityOfInvalidations { get; set; }
        public string PrimaryAssignee { get; set; }
        public string AuditorAssignee { get; set; }
        public string QualityControlAssignee { get; set; }
        public bool HasBeenObserved { get; set; }
    }
}
