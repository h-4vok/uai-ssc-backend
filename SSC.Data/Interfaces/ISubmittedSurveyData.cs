using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface ISubmittedSurveyData
    {
        void Create(SubmittedSurvey model);
    }
}
