using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
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
    }
}
