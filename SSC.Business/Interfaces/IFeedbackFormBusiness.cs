using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IFeedbackFormBusiness
    {
        void Create(FeedbackForm model);
        void UpdateIsCurrent(int id, bool isCurrent);
        FeedbackForm Get(int id);
        IEnumerable<FeedbackForm> Get();
        FeedbackForm GetCurrent();
    }
}
