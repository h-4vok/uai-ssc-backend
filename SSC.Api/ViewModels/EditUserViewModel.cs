using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class EditUserViewModel
    {
        public string UserName { get; set; }
        public int? ClientId { get; set; }
        public IEnumerable<int> RoleIds { get; set; }
    }
}