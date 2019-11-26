using DBNostalgia;
using SSC.Common;
using SSC.Common.Interfaces;
using SSC.Common.ViewModels;
using SSC.Data.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Data
{
    public class WorkOrderData : IWorkOrderData
    {
        public WorkOrderData()
        {
            this.uow = DependencyResolver.Obj.Resolve<IUnitOfWork>();
        }

        private IUnitOfWork uow;

        private WorkOrderReportRow FetchReportRow(IDataReader reader)
            => new WorkOrderReportRow
            {
                Id = reader.GetInt32("Id"),
                CreatedBy = reader.GetString("CreatedBy"),
                CurrentlyAssignedTo = reader.GetString("CurrentlyAssignedTo"),
                QuantityOfExpectedChildSamples = reader.GetInt32("QuantityOfExpectedChildSamples"),
                QuantityOfParentSamples = reader.GetInt32("QuantityOfParentSamples"),
                RequestDate = reader.GetDateTime("RequestDate"),
                StatusDescription = reader.GetString("StatusDescription"),
                TypeDescription = reader.GetString("TypeDescription"),
                UpdatedBy = reader.GetString("UpdatedBy"),
                UpdatedDate = reader.GetDateTime("UpdatedDate")
            };

        private WorkOrder Fetch(IDataReader reader) => throw new NotImplementedException();

        private void GatherParentSamples(IEnumerable<WorkOrder> models) => throw new NotImplementedException();

        private void GatherExpectedSamples(IEnumerable<WorkOrder> models) => throw new NotImplementedException();

        private Sample FetchSampleIntoParents(IDataReader reader) => throw new NotImplementedException();

        private WorkOrderExpectedSample FetchSampleIntoExpectedSample(IDataReader reader) => throw new NotImplementedException();

        public void AssignTo(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public int Create(WorkOrder model)
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            return this.uow.Run(() =>
            {
                model.Id = this.uow.Scalar("sp_WorkOrder_start",
                    ParametersBuilder.With("OrderType", model.OrderType.Code)
                        .And("TenantId", model.Tenant.Id)
                        .And("CreatedBy", auth.CurrentUserId)
                ).AsInt();

                model.ParentSamples.ForEach(ps =>
                    this.uow.NonQuery("sp_WorkOrder_addParentSample",
                        ParametersBuilder.With("SampleId", ps.Id)
                            .And("WorkOrderId", model.Id)
                            .And("CreatedBy", auth.CurrentUserId)
                    )
                );

                model.ExpectedChilds.ForEach(ec =>
                    this.uow.NonQuery("sp_WorkOrder_addExpectedSample",
                        ParametersBuilder.With("WorkOrderId", model.Id)
                            .And("ParentSampleId", ec.ParentSample.Id)
                            .And("DilutionFactor", ec.DilutionFactor)
                            .And("VolumeToUse", ec.VolumeToUse)
                            .And("ResultingVolume", ec.ResultingVolume)
                            .And("UnitOfMeasureCode", ec.UnitOfMeasure.Code)
                            .And("CreatedBy", auth.CurrentUserId)
                ));

                return model.Id;
            }, true);
        }

        public WorkOrder Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkOrderReportRow> GetReport()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();

            return this.uow.GetDirect("sp_WorkOrder_getAll", this.FetchReportRow);
        }

        protected object FetchFake(IDataReader reader) =>
            new object();

        public void MarkAsChecked(int id, IEnumerable<int> sampleIds)
        {
            this.uow.Run(() =>
            {
                // cambiar estado wo
                this.uow.NonQuery("sp_WorkOrder_ToExecuting", ParametersBuilder.With("WorkOrderId", id));

                // asignar a mi usuario
                var userId = DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId;
                this.uow.NonQuery("sp_WorkOrder_assignUser", ParametersBuilder.With("WorkOrderId", id).And("UserId", userId));

                // poner todas las samples unchecked
                this.uow.NonQuery("sp_WorkOrder_markAllUnchecked", ParametersBuilder.With("WorkOrderId", id));

                // poner checked las samples que tenemos
                sampleIds.ForEach(sampleId => 
                    this.uow.NonQuery("sp_WorkOrder_markChecked", ParametersBuilder.With("WorkOrderId", id).And("SampleId", sampleId)));

                // poner unknown a las samples que no esten checked
                this.uow.NonQuery("sp_WorkOrder_markUnknownAndReserved", ParametersBuilder.With("WorkOrderId", id));
            }, true);

        }

        public void UpdateStatus(int id, string statusCode)
        {
            throw new NotImplementedException();
        }

        protected ExpectedSampleViewModel FetchExpectedSampleViewModel(IDataReader reader)
            => new ExpectedSampleViewModel
            {
                ParentSampleId = reader.GetInt32("ParentSampleId"),
                DilutionFactor = reader.GetDecimal(reader.GetOrdinal("DilutionFactor")),
                ParentBarcode = reader.GetString("ParentBarcode"),
                ResultingVolume = reader.GetDecimal(reader.GetOrdinal("ResultingVolume")),
                UnitOfMeasureCode = reader.GetString("UnitOfMeasureCode"),
                VolumeToUse = reader.GetDecimal(reader.GetOrdinal("VolumeToUse"))
            };


        public IEnumerable<ExpectedSampleViewModel> GetExpectedSamples(int workOrderId)
        {
            return this.uow.GetDirect("sp_WorkOrder_getExpectedSamples", this.FetchExpectedSampleViewModel, ParametersBuilder.With("WorkOrderId", workOrderId));
        }

        public void Finish(int id, IEnumerable<ExpectedSampleViewModel> aliquots)
        {
            this.uow.Run(() =>
            {
                // marcamos como finalizada
                this.uow.NonQuery("sp_WorkOrder_finish", ParametersBuilder.With("WorkOrderId", id));

                // creamos samples hijos que son las alicuotas
                aliquots.ForEach(a =>
                {
                    this.uow.NonQuery("sp_WorkOrder_createAliquot",
                        ParametersBuilder.With("ParentSampleId", a.ParentSampleId)
                            .And("Barcode", a.ChildBarcode)
                            .And("Volume", a.FinalChildVolume)
                            .And("CreatedBy", DependencyResolver.Obj.Resolve<IAuthenticationProvider>().CurrentUserId)
                        );
                });

                // actualizamos samples padres (estado y volumen)
                var usedParentVolume = new Dictionary<int, decimal>();

                aliquots.Select(x => x.ParentSampleId).Distinct().ForEach(x => usedParentVolume.Add(x, 0));
                aliquots.ForEach(item => usedParentVolume[item.ParentSampleId] += item.UsedParentVolume.GetValueOrDefault());

                foreach(var parentSampleId in usedParentVolume.Keys)
                {
                    var volume = usedParentVolume[parentSampleId];

                    this.uow.NonQuery("sp_Sample_updateVolumeAndRelease",
                        ParametersBuilder.With("SampleId", parentSampleId)
                            .And("VolumeToDecrease", volume)
                    );
                }
            }, true);
        }
    }
}
