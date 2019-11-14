using DBNostalgia;
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
    public class ClientCompanyData : IClientCompanyData
    {
        public ClientCompanyData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private readonly IUnitOfWork uow;

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
                    .And("Number", ReversibleEncryption.EncryptString(model.DefaultCreditCard.Number))
                    .And("Owner", ReversibleEncryption.EncryptString(model.DefaultCreditCard.Owner))
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
            return this.uow.GetDirect("sp_ClientCompany_getAll", this.FetchReportRow);
        }

        public ClientBalanceReport GetBalanceReport(int id)
        {
            throw new NotImplementedException();
        }

        public ClientCompanyBillingInformation GetBillingInformation(int clientId)
        {
            return this.uow.GetOneDirect("sp_ClientCompanyBillingInformation_getOne", 
                this.FetchClientBillingInformation, 
                ParametersBuilder.With("ClientCompanyId", clientId));
        }

        public void UpdateBillingInformation(ClientCompanyBillingInformation model)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsEnabled(int id, bool isEnabled)
        {
            this.uow.NonQueryDirect("sp_ClientCompany_updateIsEnabled",
                ParametersBuilder.With("Id", id)
                    .And("IsEnabled", isEnabled)
                    .And("UpdatedBy", DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId)
            );
        }

        private ClientCompanyReportRow FetchReportRow(IDataReader reader)
        {
            var record = new ClientCompanyReportRow
            {
                Id = reader.GetInt32("Id"),
                BalanceStatusDescription = reader.GetString("BalanceStatusDescription"),
                IsEnabled = reader.GetBoolean("IsEnabled"),
                LastBillExpirationDate = reader.GetDateTime("LastBillExpirationDate"),
                LegalName = reader.GetString("LegalName"),
                SelectedPaymentType = reader.GetString("SelectedPaymentType"),
                SelectedPlanDescription = reader.GetString("SelectedPlanDescription"),
                TaxCode = reader.GetString("TaxCode")
            };
            return record;
        }

        private ClientCompanyBillingInformation FetchClientBillingInformation(IDataReader reader)
        {
            var record = new ClientCompanyBillingInformation
            {
                Id = reader.GetInt32("Id"),
                TaxCode = reader.GetString("TaxCode"),
                LegalName = reader.GetString("LegalName"),
                Address =
                {
                    City = reader.GetString("City"),
                    Department = reader.GetString("Department"),
                    PostalCode = reader.GetString("PostalCode"),
                    Province = {
                        Id = reader.GetInt32("ProvinceId"),
                        Name = reader.GetString("ProvinceName")
                    },
                    StreetName = reader.GetString("StreetName"),
                    StreetNumber = reader.GetString("StreetNumber")
                }
            };
            return record;
        }
    }
}
