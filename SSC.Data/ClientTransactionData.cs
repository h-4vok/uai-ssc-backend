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
    public class ClientTransactionData : IClientTransactionData
    {
        public ClientTransactionData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        public ClientTransactionReportRow FetchReportRow(IDataReader reader) => throw new NotImplementedException();

        private Receipt FetchReceipt(IDataReader reader) => throw new NotImplementedException();

        public void Create(ClientTransaction transaction)
        {
            this.uow.Run(() =>
            {
                transaction.Id = this.uow.Scalar("sp_ClientTransaction_create",
                    ParametersBuilder.With("TransactionTypeCode", transaction.TransactionType.Description)
                        .And("Total", transaction.Total)
                        .And("ClientId", transaction.ClientCompany.Id)
                        .And("ReceiptId", transaction.Receipt.Id)
                        .And("RelatedReceiptId", transaction.RelatedReceipt?.Id)
                ).AsInt();

                transaction.Payments.ForEach(p =>
                {
                    this.uow.NonQuery("sp_ClientTransaction_addPayment",
                        ParametersBuilder.With("TransactionId", transaction.Id)
                            .And("ClientCreditCardId", p.CreditCard?.Id)
                            .And("CreditCardNumber", p.Number)
                            .And("CreditCardOwner", p.Owner)
                            .And("CreditCardCCV", p.CCV)
                            .And("CreditCardExpirationDateMMYY", p.ExpirationDateMMYY)
                            .And("Amount", p.Amount)
                            .And("CreditNoteId", p.CreditNoteId)
                    );
                });
            }, true);
        }

        public IEnumerable<ClientTransactionReportRow> Get(int clientId)
        {
            throw new NotImplementedException();
        }

        public string GetNextNumber(int receiptTypeId)
        {
            throw new NotImplementedException();
        }

        public Receipt GetReceipt(int receiptId)
        {
            throw new NotImplementedException();
        }

        public bool IsPaid(int receiptId)
        {
            throw new NotImplementedException();
        }

        public void Nullify(int receiptId)
        {
            throw new NotImplementedException();
        }
    }
}
