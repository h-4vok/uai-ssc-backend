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
    public class SampleTypeController : ApiController
    {
        private ISampleTypeBusiness business;

        public SampleTypeController(ISampleTypeBusiness business) => this.business = business;

        public ResponseViewModel<IEnumerable<SampleTypeReportRow>> GetAll() => this.business.GetAll().ToList();

        public ResponseViewModel<SampleType> Get(int id) => this.business.Get(id);

        public ResponseViewModel Post(SampleType model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));

        public ResponseViewModel Put(int id, SampleType model) => ResponseViewModel.RunAndReturn(() => this.business.Update(model));

        public ResponseViewModel Delete(int id) => ResponseViewModel.RunAndReturn(() => this.business.Delete(id));
    }
}