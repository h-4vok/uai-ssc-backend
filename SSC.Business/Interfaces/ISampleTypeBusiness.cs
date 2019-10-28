using SSC.Common.ViewModels;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISampleTypeBusiness
    {
        IEnumerable<SampleTypeReportRow> GetAll();
        SampleType Get(int id);
        void Create(SampleType model);
        void Update(SampleType model);
        void Delete(int id);
    }
}
