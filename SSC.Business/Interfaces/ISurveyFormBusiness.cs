﻿using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISurveyFormBusiness
    {
        IEnumerable<SurveyForm> Get();
        SurveyForm Get(int id);
        void Create(SurveyForm model);
        void UpdateIsEnabled(int id, bool isEnabled);
    }
}
