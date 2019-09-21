using DBNostalgia;
using SSC.Common;
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
    public class ClientCompanyData : IClientCompanyData
    {
        public ClientCompanyData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        public int Create(ClientCompany model)
        {
            var apiToken = PasswordHasher.obj.Hash(String.Format("{0}[]{1}[]{2}", model.Name, model.BillingInformation.TaxCode, model.BillingInformation.LegalName));

            var output = this.uow.Run(() =>
            {
                var id = this.uow.Scalar("sp_ClientCompany_create",
                    ParametersBuilder.With("name", model.Name)
                    .And("currentPricingPlanId", model.CurrentPricingPlan.Id)
                    .And("apiToken", apiToken)).AsInt();

                model.Addresses.ForEach(record =>
                {
                    this.uow.NonQuery("sp_ClientCompanyAddress_create",
                        ParametersBuilder.With("ClientCompanyId", id)
                            .And("StreetName", record.StreetName)
                            .And("StreetNumber", record.StreetNumber)
                            .And("City", record.City)
                            .And("PostalCode", record.PostalCode)
                            .And("Department", record.Department)
                            .And("ProvinceId", record.Province.Id)
                        );
                });

                this.uow.NonQuery("sp_ClientCompanyCreditCard_create",
                    ParametersBuilder.With("ClientId", id)
                    .And("Number", model.DefaultCreditCard.Number)
                    .And("Owner", model.DefaultCreditCard.Owner)
                    .And("CCV", model.DefaultCreditCard.CCV)
                    .And("ExpirationDateMMYY", model.DefaultCreditCard.ExpirationDateMMYY)
                    .And("IsDefault", true)
                    );

                this.uow.NonQuery("sp_ClientCompanyBillingInformation_create",
                    ParametersBuilder.With("Id", id)
                    .And("LegalName", model.BillingInformation.LegalName)
                    .And("TaxCode", model.BillingInformation.TaxCode)
                    .And("StreetName", model.BillingInformation.Address.StreetName)
                    .And("StreetNumber", model.BillingInformation.Address.StreetNumber)
                    .And("City", model.BillingInformation.Address.City)
                    .And("PostalCode", model.BillingInformation.Address.PostalCode)
                    .And("Department", model.BillingInformation.Address.Department)
                    .And("ProvinceId", model.BillingInformation.Address.Province.Id)
                    );

                return id;
            }, true);

            model.ApiToken = apiToken;

            return output;
        }

        public bool Exists(string name, string taxCode)
        {
            var output = this.uow.Run(() =>
            {
                return this.uow.Scalar("sp_ClientCompany_exists", ParametersBuilder.With("name", name)).AsBool()
                    || (!String.IsNullOrEmpty(taxCode) &&
                    this.uow.Scalar("sp_ClientCompanyBillingInformation_taxCodeExists", ParametersBuilder.With("taxCode", taxCode)).AsBool());
            });

            return output;
        }

        public IEnumerable<ClientCompanyReportRow> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClientBalanceReport GetBalanceReport(int id)
        {
            throw new NotImplementedException();
        }

        public ClientCompanyBillingInformation GetBillingInformation(int clientId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBillingInformation(ClientCompanyBillingInformation model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            throw new NotImplementedException();
        }

        private ClientCompanyReportRow FetchReportRow(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private ClientCompanyBillingInformation FetchClientBillingInformation(IDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
