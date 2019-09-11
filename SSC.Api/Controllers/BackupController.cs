using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class BackupController : ApiController
    {
        private IBackupBusiness business;

        public BackupController(IBackupBusiness business) => this.business = business;

        public ResponseViewModel Post() => throw new NotImplementedException();

        public ResponseViewModel Put(int id) => throw new NotImplementedException();

        public ResponseViewModel<IEnumerable<BackupRegistry>> Get() => throw new NotImplementedException();

        public ResponseViewModel<BackupRegistry> Get(int id) => throw new NotImplementedException();
    }
}