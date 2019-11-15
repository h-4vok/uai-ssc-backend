using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SurveyFormBusiness : ISurveyFormBusiness
    {
        public SurveyFormBusiness(ISurveyFormData data) => this.data = data;

        protected ISurveyFormData data;

        public void Create(SurveyForm model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            {
                var d = model.ExpirationDate;
                d = d.Subtract(new TimeSpan(3, 0, 0));
                model.ExpirationDate = new DateTime(d.Year, d.Month, d.Day);
            }
            
            var validations = Validator<SurveyForm>.Start(model)
                .MandatoryString(x => x.QuestionTitle, i10n["survey-form.question-title"])
                .ListNotEmpty(x => x.Choices, i10n["survey-form.choices"])
                .FailWhenClosureReturnsFalse(x =>
                {
                    return !x.Choices.Any(choice => String.IsNullOrWhiteSpace(choice.ChoiceTitle));
                }, i10n["survey-form.choices.choice-title-empty"])
                .FailWhenClosureReturnsFalse(x => x.Choices.Count() > 1, i10n["survey-form.choices.need-more-than-one"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validations))
                throw new UnprocessableEntityException(validations);

            this.data.Create(model);
        }

        public IEnumerable<SurveyForm> Get(bool getOneRandom)
        {
            return this.data.Get(getOneRandom);
        }

        public SurveyForm Get(int id)
        {
            return this.data.Get(id);
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            this.data.UpdateIsEnabled(id, isEnabled);
        }
    }
}
