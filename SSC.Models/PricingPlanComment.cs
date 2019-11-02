using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class PricingPlanComment
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public string CommentBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public PricingPlan PricingPlan { get; set; }
    }
}
