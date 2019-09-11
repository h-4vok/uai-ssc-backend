using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class QueuedMail
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime QueuedDate { get; set; }
        public DateTime ToPublishDate { get; set; }
        public DateTime? SentDate { get; set; }
    }
}
