using SSC.Business;
using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml.Serialization;

namespace SSC.Api.Controllers
{
    public class PlatformMenuController : ApiController
    {
        public class RequestViewModel
        {
            public PlatformMenu PlatformMenu { get; set; }
            public string XmlSerializedItems { get; set; }
        }

        [XmlRoot]
        public class RequestXmlRoot {

            [XmlArray("Items")]
            [XmlArrayItem("Item")]
            public List<PlatformMenuItem> Items { get; set; } = new List<PlatformMenuItem>();
        }


        public PlatformMenuController(IPlatformMenuBusiness business) => this.business = business;

        protected IPlatformMenuBusiness business;

        public ResponseViewModel<IEnumerable<PlatformMenu>> Get() => this.business.GetAll().ToList();

        public ResponseViewModel<PlatformMenu> Get(int id) => this.business.Get(id);

        protected IEnumerable<PlatformMenuItem> DeserializeItems(string xml)
        {
            if (String.IsNullOrWhiteSpace(xml))
            {
                return new List<PlatformMenuItem>();
            }

            RequestXmlRoot root;
            var serializer = new XmlSerializer(typeof(RequestXmlRoot));

            using (var stream = new StringReader(xml))
                root = (RequestXmlRoot)serializer.Deserialize(stream);

            if (root != null)
                return root.Items;

            return null;
        }

        public ResponseViewModel Post(RequestViewModel viewModel)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            if (String.IsNullOrWhiteSpace(viewModel.XmlSerializedItems))
            {
                return i10n["platform-menu.validation.need-menu-items"];
            }

            var items = this.DeserializeItems(viewModel.XmlSerializedItems);

            var validationResult = Validator<RequestViewModel>.Start(viewModel)
                .MandatoryString(x => x.PlatformMenu.Code, i10n["global.code"])
                .MandatoryString(x => x.PlatformMenu.TranslationKey, i10n["platform-menu.translation-key"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validationResult))
            {
                return validationResult;
            }
            
            return ResponseViewModel.RunAndReturn(() => this.business.Create(viewModel.PlatformMenu, items));
        }

        public ResponseViewModel Put(int id, RequestViewModel viewModel)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            if (String.IsNullOrWhiteSpace(viewModel.XmlSerializedItems))
            {
                return i10n["platform-menu.validation.need-menu-items"];
            }

            viewModel.PlatformMenu.Id = id;
            var items = this.DeserializeItems(viewModel.XmlSerializedItems);

            var validationResult = Validator<RequestViewModel>.Start(viewModel)
                .MandatoryString(x => x.PlatformMenu.Code, i10n["global.code"])
                .MandatoryString(x => x.PlatformMenu.TranslationKey, i10n["platform-menu.translation-key"])
                .ValidationResult;

            if (!String.IsNullOrWhiteSpace(validationResult))
            {
                return validationResult;
            }

            return ResponseViewModel.RunAndReturn(() => this.business.Edit(viewModel.PlatformMenu, items));
        }

        public ResponseViewModel Delete(int id) => ResponseViewModel.RunAndReturn(() => this.business.Delete(id));
            
    }
}