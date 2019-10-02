using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class UserSessionViewModel
    {
        public string UserName { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public string ClientApiKey { get; set; }
    }
}
