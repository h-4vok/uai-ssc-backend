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
    public class SubmittedSurveyController : ApiController
    {
        public SubmittedSurveyController(ISubmittedSurveyBusiness business) => this.business = business;

        protected ISubmittedSurveyBusiness business;

        public ResponseViewModel Post(SubmittedSurvey model) => ResponseViewModel.RunAndReturn(() => this.business.Create(model));
    }
}