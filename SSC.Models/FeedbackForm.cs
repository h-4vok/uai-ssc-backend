using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class FeedbackForm
    {
        public int Id { get; set; }
        public bool IsCurrent { get; set; }
        public IEnumerable<FeedbackFormQuestion> Questions { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
