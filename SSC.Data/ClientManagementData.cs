﻿using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
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

        protected PricingPlan FetchPricingPlan(IDataReader reader) =>
            new PricingPlan
            {
                Code = reader.GetString("Code"),
                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                AnualDiscountPercentage = reader.GetInt32Nullable("AnualDiscountPercentage")
            };

        public PricingPlan GetPricingPlanOfClient(int clientId)
        {
            return this.uow.GetOneDirect("sp_ClientManagement_getPricingPlanOfClient",
                this.FetchPricingPlan,
                ParametersBuilder.With("ClientId", clientId)
            );
        }

        protected SelectableCreditCardViewModel FetchCreditCardViewModel(IDataReader reader) =>
            new SelectableCreditCardViewModel
            {
                CreditCard = this.FetchCreditCard(reader)
            };

        protected CreditCard FetchCreditCard(IDataReader reader) =>
            new CreditCard
            {
                Id = reader.GetInt32("Id"),
                Owner = reader.GetString("Owner"),
                Number = reader.GetString("Number"),
                ExpirationDateMMYY = reader.GetString("ExpirationDateMMYY"),
                CCV = reader.GetInt32("CCV"),
            };

        public IEnumerable<SelectableCreditCardViewModel> GetSelectableCreditCards()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            return this.uow.GetDirect("sp_ClientManagement_getClientCreditCards",
                this.FetchCreditCardViewModel,
                ParametersBuilder.With("ClientId", auth.CurrentClientId)
            );
        }

        public IEnumerable<CreditCard> GetAllCreditCards()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            var approvedCards = this.uow.GetDirect("sp_ClientManagement_getApprovedCards", this.FetchCreditCard);
            var clientCards = this.uow.GetDirect("sp_ClientManagement_getClientCards", this.FetchCreditCard, ParametersBuilder.With("ClientId", auth.CurrentClientId));

            var merged = new List<CreditCard>();
            merged.AddRange(approvedCards);
            merged.AddRange(clientCards);

            return merged;
        }
    }
}