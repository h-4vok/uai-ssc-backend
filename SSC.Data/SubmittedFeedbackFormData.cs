using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
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
    public class SubmittedFeedbackFormData : ISubmittedFeedbackFormData
    {
        public SubmittedFeedbackFormData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        public void Create(SubmittedFeedbackForm form)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            this.uow.Run(() =>
            {
                form.Id = this.uow.Scalar("sp_SubmittedFeedbackForm_create",
                    ParametersBuilder.With("FeedbackFormId", form.Form.Id)
                        .And("CreatedBy", userId)
                ).AsInt();

                foreach(var answer in form.Answers) {

                    this.uow.NonQuery("sp_SubmittedFeedbackFormAnswer_create",
                        ParametersBuilder.With("SubmittedFeedbackFormId", form.Id)
                            .And("FeedbackFormQuestionId", answer.Question.Id)
                            .And("FeedbackFormQuestionChoiceId", answer.Choice.Id)
                            .And("CreatedBy", userId)
                    );

                }
            }, true);
        }

        public bool GetHasSubmitted()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            return this.uow.ScalarDirect("sp_SubmittedFeedbackForm_hasUserSubmittedCurrent",
                ParametersBuilder.With("UserId", auth.CurrentUserId)
            ).AsBool();
        }

        protected FeedbackQuestionChartDataViewModel FetchChart(IDataReader reader)
        {
            var record = new FeedbackQuestionChartDataViewModel
            {
                QuestionTitle = reader.GetString("QuestionTitle"),
                QuestionId = reader.GetInt32("QuestionId")
            };

            return record;
        }

        protected ChartDataViewModel FetchChartData(IDataReader reader)
        {
            var record = new ChartDataViewModel
            {
                Percentage = reader.GetDecimal(reader.GetOrdinal("Percentage")),
                Count = reader.GetInt32("Count"),
                Label = reader.GetString("Label")
            };

            return record;
        }

        public IEnumerable<FeedbackQuestionChartDataViewModel> GetChartData(int surveyId)
        {
            var questions = this.uow.GetDirect("sp_SubmittedFeedbackForm_getChartQuestions", this.FetchChart,
                ParametersBuilder.With("FeedbackFormId", surveyId)
            );

            foreach(var question in questions)
            {
                question.Data = this.uow.GetDirect("sp_SubmittedFeedbackForm_getChartData", this.FetchChartData,
                    ParametersBuilder.With("QuestionId", question.QuestionId)
                );
            }

            return questions;
        }
    }
}
