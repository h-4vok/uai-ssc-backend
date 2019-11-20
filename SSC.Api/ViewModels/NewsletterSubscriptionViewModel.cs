using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.ViewModels
{
    public class NewsletterSubscriptionViewModel
    {
        public string Email { get; set; }
        public IEnumerable<SiteNewsCategory> SelectedCategories { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}