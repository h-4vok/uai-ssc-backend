using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SiteNewsArticle
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailPath { get; set; }
        public string ThumbnailRelativePath { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
