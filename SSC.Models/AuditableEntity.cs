using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public abstract class AuditableEntity
    {
        public AuditableEntity()
        {
            this.UpdatedDate = this.CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
