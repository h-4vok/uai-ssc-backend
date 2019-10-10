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

        private readonly IUnitOfWork uow;

        private ClientTestimonial FetchTestimonial(IDataReader reader)
        {
            var record = new ClientTestimonial
            {
                Id = reader.GetInt32("Id"),
                Client = new ClientCompany
                {
                    Id = reader.GetInt32("ClientCompanyId"),
                    Name = reader.GetString("ClientCompanyName")
                },
                PersonFullName = reader.GetString("PersonFullName"),
                CreatedDate = reader.GetDateTime("CreatedDate"),
                TestimonialText = reader.GetString("TestimonialText")
            };
            return record;
        }

        private Address FetchAddress(IDataReader reader)
        {
            var record = new Address
            {
                Id = reader.GetInt32("Id"),
                StreetName = reader.GetString("StreetName"),
                StreetNumber = reader.GetString("StreetNumber"),
                City = reader.GetString("City"),
                Department = reader.GetString("Department"),
                PostalCode = reader.GetString("PostalCode"),
                Province = new Province
                {
                    Id = reader.GetInt32("ProvinceId"),
                    Name = reader.GetString("ProvinceName")
                }
            };
            return record;
        }

        public Address GetAddress()
        {
            return this.uow.GetOneDirect("sp_AboutUs_address", this.FetchAddress);
        }

        public IEnumerable<ClientTestimonial> GetLast5()
        {
            return this.uow.GetDirect("sp_ClientTestimonial_getLast5", this.FetchTestimonial);
        }
    }
}
