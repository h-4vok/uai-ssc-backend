using DBNostalgia;
using SSC.Common;
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
    public class AboutUsData : IAboutUsData
    {
        public AboutUsData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private ClientTestimonial FetchTestimonial(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        private Address FetchAddress(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Address GetAddress()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientTestimonial> GetLast5()
        {
            throw new NotImplementedException();
        }
    }
}
