using SSC.Business.Interfaces;
using SSC.Common;
using SSC.Common.Exceptions;
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
            var volumeToUse = new Dictionary<int, decimal>();

            Validator<StartWorkOrderViewModel>.Start(model)
                .ListNotEmpty(x => x.ParentSamples, i10n["work-order.start.validation.parent-samples-empty"])
                .ListNotEmpty(x => x.ExpectedChilds, i10n["work-order.start.validation.expected-childs-empty"])
                .FailWhenClosureReturnsFalse(x =>
                {
                    model.ParentSamples.Select(p => p.Id).Distinct().ForEach(sampleId => volumeToUse.Add(sampleId, 0));

                    foreach (var expectedChild in x.ExpectedChilds)
                    {
                        Validator<ExpectedChildViewModel>.Start(expectedChild)
                            .Int2PositiveNonZero(item => item.ExpectedChildQuantity, i10n["work-order.start.field.expected-child-quantity"])
                            .DecimalPositiveNonZero(item => item.DilutionFactor, i10n["work-order.start.field.dilution-factor"])
                            .DecimalPositiveNonZero(item => item.ResultingVolume, i10n["work-order.start.field.resulting-volume"])
                            .ThrowExceptionIfApplicable();

                        var parentId = x.ParentSamples.First(item => item.Barcode == expectedChild.ParentBarcode).Id;
                        volumeToUse[parentId] += 
                           expectedChild.ExpectedChildQuantity.Value * (expectedChild.ResultingVolume.Value / expectedChild.DilutionFactor.Value) ;
                    }

                    return true;
                }, ""
                )
                .ThrowExceptionIfApplicable();

            foreach (var sampleId in volumeToUse.Keys)
            {
                var sample = model.ParentSamples.First(x => x.Id == sampleId);

                if (sample.AvailableVolume < volumeToUse[sampleId])
                {
                    throw new UnprocessableEntityException(
                        String.Format(
                            i10n["work-order.start.field.too-much-volume"], 
                            sample.Barcode, 
                            sample.AvailableVolume, 
                            volumeToUse[sampleId], 
                            sample.UnitOfMeasureCode));
                }
            }

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

        public void CheckSamples(int workOrderId, IEnumerable<CheckableSampleReportRow> checkedSamples)
        {
            var sampleIds = checkedSamples.Where(x => x.Checked).Select(x => x.Id);

            this.data.MarkAsChecked(workOrderId, sampleIds);
        }

        public IEnumerable<ExpectedSampleViewModel> GetExpectedSamples(int workOrderId)
        {
            var items = this.data.GetExpectedSamples(workOrderId);
            var parentItems = new Dictionary<string, int>();

            items.Select(x => x.ParentBarcode).Distinct().ForEach(x => parentItems.Add(x, 0));

            items.ForEach(x =>
            {
                var count = parentItems[x.ParentBarcode]++;
                x.ChildBarcode = String.Concat(x.ParentBarcode, (char) (65 + count));
            });

            return items;
        }

        public void Finish(int id, FinishWorkOrderViewModel model)
        {
            var i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();

            foreach(var item in model.Aliquots)
            {
                Validator<ExpectedSampleViewModel>.Start(item)
                    .DecimalPositiveNonZero(x => x.UsedParentVolume, i10n["execute-work-order.grid.UsedParentVolume"])
                    .DecimalPositiveNonZero(x => x.FinalChildVolume, i10n["execute-work-order.grid.FinalChildVolume"])
                    .ThrowExceptionIfApplicable();
            }

            this.data.Finish(id, model.Aliquots);
        }

        public void Cancel(int id)
        {
            this.data.Cancel(id);
        }
    }
}
