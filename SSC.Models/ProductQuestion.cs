using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ProductQuestion
    {
        public int Id { get; set; }
        public string QuestionBy { get; set; }
        public string Question { get; set; }
        public int? ReplyBy { get; set; }
        public string ReplyByDescription { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime? RepliedDate { get; set; }
        public string Reply { get; set; }
        public int PricingPlanId { get; set; }
        public string PricingPlanCode { get; set; }
        public string PricingPlanName { get; set; }
    }
}
