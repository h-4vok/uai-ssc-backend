using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClinicRun
    {
        public int Id { get; set; }
        public User CurrentAssignee { get; set; }
        public ClinicRunStatus Status { get; set; }
        public ClinicRunStage Stage { get; set; }
        public User PrimaryAssignee { get; set; }
        public User AuditorAssignee { get; set; }
        public User QualityControlAssignee { get; set; }
        public ClientCompany Tenant { get; set; }
        public IEnumerable<Sample> Samples { get; set; }
        public IEnumerable<ClinicRunInvalidation> Invalidations { get; set; }
        public IEnumerable<ClinicRunExecution> Executions { get; set; }
        public IEnumerable<ClinicRunComment> CommentsLog { get; set; }
    }
}
