using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ProfitReportRow
    {
        public DateTime Date { get; set; }
        public int Year { get => this.Date.Year; }
        public int Month { get => this.Date.Month; }
        public int Day { get => this.Date.Day; } 
        public decimal Profit { get; set; }
    }
}
