﻿using SSC.Api.Behavior;
using SSC.Api.ViewModels;
using SSC.Business.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class NewsletterController : ApiController
    {
        private ISiteNewsBusiness business;

        public NewsletterController(ISiteNewsBusiness business) => this.business = business;

        public ResponseViewModel Put(int id, NewNewsletterDistributionModel model) => throw new NotImplementedException();

        [SscAuthorize(Permissions = "NEWS_MANAGEMENT")]
        public ResponseViewModel  Post(NewNewsletterDistributionModel model) 
            => ResponseViewModel.RunAndReturn(() => this.business.SendNewsletter(model.DateFrom, model.DateTo, model.IncomingHost));

        public ResponseViewModel Delete(string email) => throw new NotImplementedException();
    }
}