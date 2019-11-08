using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SubmittedFeedbackForm
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public FeedbackForm Form { get; set; }
        public IEnumerable<SubmittedFeedbackFormAnswer> Answers { get; set; } = new List<SubmittedFeedbackFormAnswer>();
    }
}
