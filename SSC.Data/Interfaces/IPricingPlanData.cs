﻿using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data.Interfaces
{
    public interface IPricingPlanData
    {
        IEnumerable<PricingPlan> GetAll(string nameAlike, int minPrice, int maxPrice, int minRating);
        PricingPlan GetByCode(string code);
    }
}
