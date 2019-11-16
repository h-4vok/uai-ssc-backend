using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class SiteNewsThumbnailController : ApiController
    {
        public SiteNewsThumbnailController(ISiteNewsBusiness business) => this.business = business;

        protected ISiteNewsBusiness business;

        [HttpPut]
        public ResponseViewModel Put(int id)
        {
            var request = HttpContext.Current.Request;
            var dir = ConfigurationManager.AppSettings["SiteNewsImabes.Path"];
            var fulldir = HostingEnvironment.MapPath(dir);
            Directory.CreateDirectory(fulldir);

            var filename = String.Format("{0}{1}", Guid.NewGuid(), request.Headers["thumbnail-filename"]);
            var filepath = Path.Combine(fulldir, filename);
            var relativepath = Path.Combine(dir, filename).Replace("~", "");

            using (var fs = new FileStream(filepath, FileMode.Create))
            {
                request.InputStream.CopyTo(fs);
            }

            this.business.SetThumbnail(id, filepath, relativepath);

            return true;
        }
    }
}