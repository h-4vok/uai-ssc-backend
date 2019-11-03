using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class PlatformMenu
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TranslationKey { get; set; }
        public int MenuOrder { get; set; }
        public List<PlatformMenuItem> Items { get; set; } = new List<PlatformMenuItem>();
    }
}
