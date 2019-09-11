using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class FileUploadViewModel
    {
        public string Data { get; set; }
        public string FileName { get; set; }
        public int ClinicRunId { get; set; }
    }
}