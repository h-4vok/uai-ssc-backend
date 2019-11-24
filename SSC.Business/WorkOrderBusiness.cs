using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Interfaces;
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
    public class WorkOrderBusiness : IWorkOrderBusiness
    {
        public WorkOrderBusiness()
        {
            this.data = DependencyResolver.Obj.Resolve<IWorkOrderData>();
        }
        private IWorkOrderData data;

        public int Create(StartWorkOrderViewModel model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            Validator<StartWorkOrderViewModel>.Start(model)
                .ListNotEmpty(x => x.ParentSamples, i10n["work-order.start.validation.parent-samples-empty"])
                .FailWhenClosureReturnsFalse(x =>
                {
                    foreach (var expectedChild in x.ExpectedChilds)
                    {
                        Validator<ExpectedChildViewModel>.Start(expectedChild)
                            .Int2PositiveNonZero(item => item.ExpectedChildQuantity, i10n["work-order.start.field.expected-child-quantity"])
                            .DecimalPositiveNonZero(item => item.DilutionFactor, i10n["work-order.start.field.dilution-factor"])
                            .DecimalPositiveNonZero(item => item.ResultingVolume, i10n["work-order.start.field.resulting-volume"])
                            .ThrowExceptionIfApplicable();
                    }

                    return true;
                }, ""
                )
                .ThrowExceptionIfApplicable();

            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            var workOrder = new WorkOrder
            {
                OrderType = new WorkOrderType { Code = "aliquot" },
                ParentSamples = model.ParentSamples.Select(x => new Sample { Id = x.Id }),
                ExpectedChilds = this.buildExpectedChilds(model.ExpectedChilds, model.ParentSamples),
                Tenant = new ClientCompany { Id = auth.CurrentClientId }
            };

            return this.data.Create(workOrder);
        }

        private IEnumerable<WorkOrderExpectedSample> buildExpectedChilds(IEnumerable<ExpectedChildViewModel> expectedChilds, IEnumerable<SampleReportRow> parentSamples)
        {
            var output = new List<WorkOrderExpectedSample>();

            foreach(var meta in expectedChilds)
            {
                WorkOrderExpectedSample prototyper() =>
                    new WorkOrderExpectedSample
                    {
                        DilutionFactor = meta.DilutionFactor.GetValueOrDefault(),
                        ResultingVolume = meta.ResultingVolume.GetValueOrDefault(),
                        UnitOfMeasure = new UnitOfMeasure { Code = meta.UnitOfMeasureCode },
                        VolumeToUse = meta.ResultingVolume.GetValueOrDefault() / meta.DilutionFactor.GetValueOrDefault(),
                        ParentSample = new Sample { Id = parentSamples.First(p => p.Barcode == meta.ParentBarcode).Id }
                    };

                for (var i = 0; i < meta.ExpectedChildQuantity; i++)
                {
                    output.Add(prototyper());
                }
            }

            return output;
        }

        public WorkOrder Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkOrderReportRow> GetReport()
        {
            return this.data.GetReport();
        }

        public void MarkAsChecked(int id, string sampleCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int id, string statusCode)
        {
            throw new NotImplementedException();
        }
    }
}
