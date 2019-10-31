using SSC.Api.Behavior;
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

        [SscAuthorize(Permissions = "PLATFORM_BACKUP")]
        public ResponseViewModel Post(BackupRegistry model) => ResponseViewModel.RunAndReturn(() => this.business.DoBackup());

        [SscAuthorize(Permissions = "PLATFORM_RESTORE")]
        public ResponseViewModel Put(int id, BackupRegistry model) => ResponseViewModel.RunAndReturn(() => this.business.DoRestore(id));

        [SscAuthorize(Permissions = "PLATFORM_BACKUP,PLATFORM_RESTORE")]
        public ResponseViewModel<IEnumerable<BackupRegistry>> Get() => this.business.GetAll().ToList();

        [SscAuthorize(Permissions = "PLATFORM_BACKUP,PLATFORM_RESTORE")]
        public ResponseViewModel<BackupRegistry> Get(int id) => this.business.Get(id);
    }
}