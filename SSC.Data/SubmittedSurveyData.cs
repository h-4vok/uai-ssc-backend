using DBNostalgia;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class SubmittedSurveyData : ISubmittedSurveyData
    {
        public SubmittedSurveyData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        public void Create(SubmittedSurvey model)
        {
            this.uow.NonQueryDirect("sp_SubmittedSurvey_create",
                ParametersBuilder.With("SurveyFormId", model.SurveyForm.Id)
                    .And("SurveyChoiceId", model.SurveyChoice.Id)
            );
        }

        protected ChartDataViewModel FetchChartData(IDataReader reader)
        {
            var record = new ChartDataViewModel
            {
                Data = reader.GetDecimal(reader.GetOrdinal("Data")),
                Label = reader.GetString("Label")
            };

            return record;
        }

        public IEnumerable<ChartDataViewModel> GetChartData(int surveyId)
        {
            return this.uow.GetDirect("sp_SubmittedSurvey_getChartData", this.FetchChartData,
                ParametersBuilder.With("SurveyFormId", surveyId)
            );
        }
    }
}
