using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SubmittedSurvey
    {
        public int Id { get; set; }
        public SurveyForm SurveyForm { get; set; }
        public SurveyChoice SurveyChoice { get; set; }
    }
}
