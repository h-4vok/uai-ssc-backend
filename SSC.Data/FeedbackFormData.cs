using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
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
    public class FeedbackFormData : IFeedbackFormData
    {
        public FeedbackFormData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        protected FeedbackForm Fetch(IDataReader reader)
        {
            var record = new FeedbackForm
            {
                Id = reader.GetInt32("Id"),
                IsCurrent = reader.GetBoolean("IsCurrent"),
                CreatedDate = reader.GetDateTime("CreatedDate")
            };

            return record;
        }

        protected FeedbackFormQuestion FetchQuestion(IDataReader reader)
        {
            var record = new FeedbackFormQuestion
            {
                Id = reader.GetInt32("Id"),
                Question = reader.GetString("Question")
            };

            return record;
        }

        protected FeedbackFormQuestionChoice FetchChoice(IDataReader reader)
        {
            var record = new FeedbackFormQuestionChoice
            {
                Id = reader.GetInt32("Id"),
                ChoiceTitle = reader.GetString("ChoiceTitle")
            };

            return record;
        }

        public void Create(FeedbackForm model)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            this.uow.Run(() =>
            {
                model.Id = this.uow.Scalar("sp_FeedbackForm_create",
                    ParametersBuilder.With("IsCurrent", model.IsCurrent)
                        .And("CreatedBy", userId)
                ).AsInt();

                foreach (var question in model.Questions)
                {
                    question.Id = this.uow.Scalar("sp_FeedbackFormQuestion_create",
                        ParametersBuilder.With("FeedbackFormId", model.Id)
                            .And("Question", question.Question)
                            .And("CreatedBy", userId)
                    ).AsInt();

                    foreach (var choice in question.Choices)
                    {
                        this.uow.NonQuery("sp_FeedbackFormQuestionChoice_create",
                            ParametersBuilder.With("FeedbackFormQuestionId", question.Id)
                                .And("ChoiceTitle", choice.ChoiceTitle)
                                .And("CreatedBy", userId)
                            );
                    }
                }
            }, true);
        }

        public FeedbackForm Get(int id)
        {
            var output = this.uow.Run(() =>
            {
                var form = this.uow.GetOne("sp_FeedbackForm_getOne", this.Fetch, ParametersBuilder.With("Id", id));

                form.Questions = this.uow.Get("sp_FeedbackForm_getQuestions", this.FetchQuestion, ParametersBuilder.With("Id", form.Id));

                foreach(var question in form.Questions)
                {
                    question.Choices = this.uow.Get("sp_FeedbackFormQuestion_getChoices", this.FetchChoice, ParametersBuilder.With("Id", question.Id));
                }

                return form;
            });

            return output;
        }

        public IEnumerable<FeedbackForm> Get()
        {
            return this.uow.GetDirect("sp_FeedbackForm_get", this.Fetch);
        }

        public FeedbackForm GetCurrent()
        {       
            var id = this.uow.ScalarDirect("sp_FeedbackForm_getCurrent").AsInt();

            return this.Get(id);
        }

        public void UpdateIsCurrent(int id, bool isCurrent)
        {
            this.uow.NonQueryDirect("sp_FeedbackForm_updateIsCurrent", ParametersBuilder.With("Id", id).And("IsCurrent", isCurrent));
        }
    }
}
