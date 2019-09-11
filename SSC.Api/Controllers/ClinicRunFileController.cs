using SSC.Api.ViewModels;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class ClinicRunFileController : ApiController
    {
        private IFileSystemProvider business;

        public ClinicRunFileController(IFileSystemProvider business) => this.business = business;

        public ResponseViewModel Post(FileUploadViewModel model) => throw new NotImplementedException();

        public ResponseViewModel<string> Get(int id) => throw new NotImplementedException();
    }
}