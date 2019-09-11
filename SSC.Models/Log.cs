using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public abstract class Log
    {
        public int Id { get; set; }
        public DateTime LoggedDate { get; set; }
        public string UserReference { get; set; }
        public int ClientId { get; set; }
        public EventType EventType { get; set; }
        public string Message { get; set; }
    }
}
