using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class WorkOrderReportRow
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string CreatedBy { get; set; }
        public string TypeDescription { get; set; }
        public uint QuantityOfParemtSamples { get; set; }
        public uint QuantityOfExpectedChildSamples { get; set; }
        public string StatusDescription { get; set; }
        public string CurrentlyAssignedTo { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
