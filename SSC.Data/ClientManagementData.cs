using DBNostalgia;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class ClientManagementData : IClientManagementData
    {
        public ClientManagementData(IUnitOfWork uow) => this.uow = uow;

        protected IUnitOfWork uow;

        protected ClientLandingViewModel FetchClientLanding(IDataReader reader) =>
            new ClientLandingViewModel
            {
                ServicePlanName = reader.GetString("ServicePlanName"),
                ServiceExpirationDescription = reader.GetDateTime("ServiceExpirationDescription").ToString("dd/MM/yyyy")
            };

        public ClientLandingViewModel GetLandingData(int clientId)
        {
            return this.uow.GetOneDirect("sp_ClientManagement_getLandingData", 
                this.FetchClientLanding, 
                ParametersBuilder.With("ClientId", clientId));
        }
    }
}
