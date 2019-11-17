using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
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
    public class ReceiptData : IReceiptData
    {
        public ReceiptData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        public Receipt Fetch(IDataReader reader) => throw new NotImplementedException();

        public Receipt GetLastBill(int clientId)
        {
            throw new NotImplementedException();
        }

        public void CreateNewBill(Receipt<ReceiptLine> receipt)
        {
            var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;

            this.uow.Run(() =>
            {
                receipt.Id = this.uow.Scalar("sp_Receipt_create",
                    ParametersBuilder.With("ClientId", receipt.Client.Id)
                        .And("ReceiptTypeCode", receipt.ReceiptType.Code)
                        .And("CreatedBy", userId)
                ).AsInt();

                receipt.Number = this.uow.Scalar("sp_Receipt_getNumber", ParametersBuilder.With("Id", receipt.Id)).AsString();

                receipt.Lines.ForEach(line =>
                {
                    this.uow.NonQuery("sp_ReceiptLine_create",
                        ParametersBuilder.With("ReceiptId", receipt.Id)
                        .And("Concept", line.Concept)
                        .And("Subtotal", line.Subtotal)
                        .And("Taxes", line.Taxes)
                        .And("CreatedBy", userId)
                    );
                });

            }, true);
        }
    }
}
