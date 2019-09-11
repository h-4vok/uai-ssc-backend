using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.ViewModels
{
    public class ClientMemberReportRow
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsCompanyEnabled { get; set; }
        public bool IsBlocked { get; set; }
        public bool HasPEndingInvitation { get; set; }
        public DateTime InvitationDateTime { get; set; }
        public string InvitedBy { get; set; }
        public string RolesDescription { get; set; }
        public int QuantityOfPermissions { get; set; }
    }
}
