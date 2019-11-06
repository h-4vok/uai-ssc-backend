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
    public class FeedbackFormBusiness : IFeedbackFormBusiness
    {
        public FeedbackFormBusiness(IFeedbackFormData data) => this.data = data;

        protected IFeedbackFormData data;

        public void Create(FeedbackForm model)
        {
            this.data.Create(model);
        }

        public FeedbackForm Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<FeedbackForm> Get()
        {
            return this.data.Get();
        }

        public FeedbackForm GetCurrent()
        {
            return this.data.GetCurrent();
        }

        public void UpdateIsCurrent(int id, bool isCurrent)
        {
            this.data.UpdateIsCurrent(id, isCurrent);
        }
    }
}
