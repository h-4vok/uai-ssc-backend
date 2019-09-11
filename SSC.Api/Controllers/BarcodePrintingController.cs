using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class BarcodePrintingController : ApiController
    {
        private IDataToBlobProcessor<object, byte[]> pdfProcessor;

        public BarcodePrintingController(IDataToBlobProcessor<object, byte[]> pdfProcessor)
        {
            this.pdfProcessor = new DataToPDFProcessor<object>();
        }

        public ResponseViewModel Get(string barcode) => throw new NotImplementedException();
    }
}