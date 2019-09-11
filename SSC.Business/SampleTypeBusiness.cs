using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SampleTypeBusiness : ISampleTypeBusiness
    {
        public SampleTypeBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<ISampleTypeData>();
            this.languageBusiness = DependencyResolver.Obj.Resolve<ISystemLanguageBusiness>();
        }
        private ISampleTypeData data;
        private ISystemLanguageBusiness languageBusiness;

        public int Create(SampleType model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SampleType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleTypeReportRow> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SampleType model)
        {
            throw new NotImplementedException();
        }
    }
}
