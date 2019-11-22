using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class BackupRegistry
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public DateTime BackupDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsPathOnly { get; set; }
    }
}
