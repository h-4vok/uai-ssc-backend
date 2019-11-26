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
    public class SampleData : ISampleData
    {
        public SampleData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private SampleReportRow FetchReportRow(IDataReader reader)
            => new SampleReportRow
            {
                Id = reader.GetInt32("Id"),
                Barcode = reader.GetString("Barcode"),
                SampleTypeCode = reader.GetString("SampleTypeCode"),
                AvailableVolume = reader.GetDecimal(reader.GetOrdinal("AvailableVolume")),
                UnitOfMeasureCode = reader.GetString("UnitOfMeasureCode")
            };

        private CheckableSampleReportRow FetchCheckableReportRow(IDataReader reader) 
            => new CheckableSampleReportRow
            {
                Id = reader.GetInt32("Id"),
                Barcode = reader.GetString("Barcode"),
                SampleTypeCode = reader.GetString("SampleTypeCode"),
                AvailableVolume = reader.GetDecimal(reader.GetOrdinal("AvailableVolume")),
                UnitOfMeasureCode = reader.GetString("UnitOfMeasureCode")
            };

        public IEnumerable<SampleReportRow> GetSamples(int clientId, string statusCode)
        {
            return this.uow.GetDirect("sp_Samples_get",
                this.FetchReportRow,
                ParametersBuilder.With("StatusCode", statusCode)
            );
        }

        public IEnumerable<CheckableSampleReportRow> GetParentSamplesOfWorkOrder(int workOrderId)
        {
            return this.uow.GetDirect("sp_Samples_getParentSamplesOfWorkOrder",
                this.FetchCheckableReportRow,
                ParametersBuilder.With("WorkOrderId", workOrderId));
        }
    }
}
