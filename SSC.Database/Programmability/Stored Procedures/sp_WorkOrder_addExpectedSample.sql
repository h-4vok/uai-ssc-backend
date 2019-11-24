CREATE PROCEDURE sp_WorkOrder_addExpectedSample
	@WorkOrderId INT,
	@ParentSampleId INT,
	@DilutionFactor NUMERIC(10, 2),
	@VolumeToUse NUMERIC(10, 2),
	@ResultingVolume NUMERIC(10, 2),
	@UnitOfMeasureCode NVARCHAR(100),
	@CreatedBy INT
AS
BEGIN

	DECLARE @UnitOfMeasureId INT

	SELECT @UnitOfMeasureId = Id FROM UnitOfMeasure WHERE Code = @UnitOfMeasureCode

	INSERT WorkOrderExpectedSample (
		CreatedBy,
		DilutionFactor,
		ParentSampleId,
		ResultingVolume,
		UnitOfMeasureId,
		UpdatedBy,
		VolumeToUse,
		WorkOrderId
	)
	SELECT
		CreatedBy = @CreatedBy,
		DilutionFactor = @DilutionFactor,
		ParentSampleId = @ParentSampleId,
		ResultingVolume = @ResultingVolume,
		UnitOfMeasureId = @UnitOfMeasureId,
		UpdatedBy = @CreatedBy,
		VolumeToUse = @VolumeToUse,
		WorkOrderId = @WorkOrderId

END