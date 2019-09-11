using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SampleTransaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public SampleTransactionOrigin Origin { get; set; }
        public string OriginDescriptor { get; set; }
        public SampleTransactionConcept Concept { get; set; }
        public decimal Value { get; set; }
        public decimal BalanceAtTransactionTime { get; set; }
        public Sample Sample { get; set; }
    }
}
