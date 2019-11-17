using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public ClientCompany Client { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ReceiptType ReceiptType { get; set; }
        public bool IsNullified { get; set; }
        public string Number { get; set; }
    }
    public class Receipt<T> : Receipt
    {
        public IList<T> Lines { get; set; } = new List<T>();
    }
}
