using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class CreditCardBusiness : ICreditCardBusiness
    {
        public CreditCardBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ICreditCardData>();
            this.externalValidator = DependencyResolver.Obj.Resolve<IExternalCreditCardValidator>();
        }
        private ICreditCardData data;
        private IExternalCreditCardValidator externalValidator;

        public void Create(CreditCard model)
        {
            this.data.Create(model);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreditCardReportRow> GetAll(int clientId)
        {
            throw new NotImplementedException();
        }

        public bool IsFromCurrentClient(int id, int clientId)
        {
            throw new NotImplementedException();
        }

        public void MakeDefault(int id)
        {
            throw new NotImplementedException();
        }

        public string ValidateData(CreditCard model)
        {
            return this.externalValidator.Validate(model.Number, model.CCV.ToString(), model.Owner, model.ExpirationDateMMYY);
        }
    }
}
