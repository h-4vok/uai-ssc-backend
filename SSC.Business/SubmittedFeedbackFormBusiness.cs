using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SubmittedFeedbackFormBusiness : ISubmittedFeedbackFormBusiness
    {
        public SubmittedFeedbackFormBusiness(ISubmittedFeedbackFormData data) => this.data = data;

        protected ISubmittedFeedbackFormData data;

        public void Create(SubmittedFeedbackForm form)
        {
            this.data.Create(form);
        }

        public bool GetHasSubmitted()
        {
            return this.data.GetHasSubmitted();
        }

        public IEnumerable<FeedbackQuestionChartDataViewModel> GetChartData(int surveyId)
        {
            return this.data.GetChartData(surveyId);
        }
    }
}
