using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SurveyForm
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime ExpirationDate { get; set; }
        public IEnumerable<SurveyChoice> Choices { get; set; } = new List<SurveyChoice>();
    }
}
