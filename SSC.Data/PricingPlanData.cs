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
    public class PricingPlanData : IPricingPlanData
    {
        public PricingPlanData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private PricingPlan Fetch(IDataReader reader)
        {
            var output = new PricingPlan
            {
                Id = reader.GetInt32("Id"),
                Code = reader.GetString("Code"),
                Name = reader.GetString("Name"),
                UserLimit = reader.GetInt32Nullable("UserLimit"),
                PatientSampleLimit = reader.GetInt32Nullable("PatientSampleLimit"),
                ControlSampleLimit = reader.GetInt32Nullable("ControlSampleLimit"),
                ClinicRehearsalLimit = reader.GetInt32Nullable("ClinicRehearsalLimit"),
                AnualDiscountPercentage = reader.GetInt32Nullable("AnualDiscountPercentage"),
                Price = reader.GetDecimal(reader.GetOrdinal("Price"))
            };

            return output;
        }

        public IEnumerable<PricingPlan> GetAll(string nameAlike, int minPrice, int maxPrice, int minRating)
        {
            var output = this.uow.GetDirect("sp_PricingPlan_getAll", this.Fetch,
                ParametersBuilder.With("nameAlike", nameAlike)
                    .And("minPrice", minPrice)
                    .And("maxPrice", maxPrice)
                    .And("minRating", minRating)
            );
            return output;
        }

        public PricingPlan GetByCode(string code)
        {
            var output = this.uow.GetOneDirect("sp_PricingPlan_getByCode", this.Fetch, ParametersBuilder.With("Code", code));
            return output;
        }
    }
}
