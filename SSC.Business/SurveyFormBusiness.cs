using SSC.Business.Interfaces;
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
            this.data.Create(model);
        }

        public IEnumerable<SurveyForm> Get()
        {
            return this.data.Get();
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
