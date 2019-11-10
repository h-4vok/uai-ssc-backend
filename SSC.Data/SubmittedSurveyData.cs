using DBNostalgia;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
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
    }
}
