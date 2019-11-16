using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface IClientManagementBusiness
    {
        ClientLandingViewModel GetLandingData();
    }
}
