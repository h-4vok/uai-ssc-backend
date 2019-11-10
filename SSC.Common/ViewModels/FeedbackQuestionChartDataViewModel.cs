using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class FeedbackQuestionChartDataViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public IEnumerable<ChartDataViewModel> Data { get; set; } = new List<ChartDataViewModel>();
    }
}
