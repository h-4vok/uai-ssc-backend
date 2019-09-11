using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class SampleTransactionReportRow
    {
        public int Id { get; set; }
        public int SampleId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string OriginDescription { get; set; }
        public string OriginIdentifier { get; set; }
        public string ConceptDescription { get; set; }
        public decimal Value { get; set; }
        public decimal BalanceAtTransactionTime { get; set; }
    }
}
