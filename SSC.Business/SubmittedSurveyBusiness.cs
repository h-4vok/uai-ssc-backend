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
    public class SubmittedSurveyBusiness : ISubmittedSurveyBusiness
    {
        public SubmittedSurveyBusiness(ISubmittedSurveyData data) => this.data = data;

        protected ISubmittedSurveyData data;
        
        public void Create(SubmittedSurvey model)
        {
            this.data.Create(model);
        }

        public IEnumerable<ChartDataViewModel> GetChartData(int surveyId)
        {
            return this.data.GetChartData(surveyId);
        }
    }
}
