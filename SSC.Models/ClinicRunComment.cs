using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class ClinicRunComment
    {
        public int Id { get; set; }
        public User CommentsBy { get; set; }
        public string Comments { get; set; }
    }
}
