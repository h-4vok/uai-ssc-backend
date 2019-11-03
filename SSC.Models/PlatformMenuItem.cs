using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SSC.Models
{
    public class PlatformMenuItem
    {
        public int Id { get; set; }
        public PlatformMenu PlatformMenu { get; set; }
        public int MenuOrder { get; set; }
        public string RelativeRoute { get; set; }
        public string TranslationKey { get; set; }
        
        [XmlArray("RequiredPermissions")]
        [XmlArrayItem("Permission")]
        public List<Permission> RequiredPermissions { get; set; } = new List<Permission>();
    }
}
