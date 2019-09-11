using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public WorkOrderStatus Status { get; set; }
        public ClientCompany Tenant { get; set; }
        public DateTime RequestDate { get; set; }
        public string CreatedBy { get; set; }
        public WorkOrderType OrderType { get; set; }
        public User CurrentAssignedUser { get; set; }
        public IEnumerable<Sample> ParentSamples { get; set; }
        public IEnumerable<WorkOrderExpectedSample> ExpectedChilds { get; set; }
        public HashSet<string> CheckedSamples { get; set; }
    }
}
