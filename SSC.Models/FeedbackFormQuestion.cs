using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class FeedbackFormQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public IEnumerable<FeedbackFormQuestionChoice> Choices { get; set; }
    }
}
