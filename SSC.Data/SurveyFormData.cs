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
    public class SurveyFormData : ISurveyFormData
    {
        public SurveyFormData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        public void Create(SurveyForm model)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            this.uow.Run(() =>
            {
                model.Id = this.uow.Scalar("sp_SurveyForm_create",
                    ParametersBuilder.With("QuestionTitle", model.QuestionTitle)
                        .And("CreatedBy", userId)
                ).AsInt();

                model.Choices.ForEach(choice =>
                {
                    this.uow.NonQuery("sp_SurveyChoice_create",
                        ParametersBuilder.With("ChoiceTitle", choice.ChoiceTitle)
                            .And("SurveyFormId", model.Id)
                            .And("CreatedBy", userId)
                    );
                });

            }, true);
        }

        protected SurveyForm Fetch(IDataReader reader)
        {
            var record = new SurveyForm
            {
                Id = reader.GetInt32("Id"),
                QuestionTitle = reader.GetString("QuestionTitle"),
                IsEnabled = reader.GetBoolean("IsEnabled")
            };

            return record;
        }

        public IEnumerable<SurveyForm> Get()
        {
            return this.uow.GetDirect("sp_SurveyForm_getAll", this.Fetch);
        }

        protected SurveyChoice FetchChoice(IDataReader reader)
        {
            var record = new SurveyChoice
            {
                Id = reader.GetInt32("Id"),
                ChoiceTitle = reader.GetString("ChoiceTitle")
            };

            return record;
        }

        public SurveyForm Get(int id)
        {
            return this.uow.Run(() =>
            {
                var model = this.uow.GetOne("sp_SurveyForm_getOne", this.Fetch, ParametersBuilder.With("Id", id));

                model.Choices = this.uow.Get("sp_SurveyChoice_getForForm", this.FetchChoice, ParametersBuilder.With("Id", id));

                return model;
            });
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            this.uow.NonQueryDirect("sp_SurveyForm_updateIsEnabled",
                ParametersBuilder.With("Id", id)
                .And("IsEnabled", isEnabled)
            );
        }
    }
}
