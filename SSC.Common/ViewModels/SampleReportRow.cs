using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class SampleReportRow
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public int SampleTypeId { get; set; }
        public string SampleTypeCode { get; set; }
        public int SampleFunctionId { get; set; }
        public string SampleFunctionCode { get; set; }
        public decimal OriginalVolume { get; set; }
        public decimal AvailableVolume { get; set; }
        public int UnitOfMeasureId { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string ParametersString { get; set; }
        public int QuantityOfTransactions { get; set; }
        public int QuantityOfImmediateChilds { get; set; }
        public string PatientName { get; set; }
    }
}
