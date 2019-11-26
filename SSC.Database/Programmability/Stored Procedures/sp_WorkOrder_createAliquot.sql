CREATE PROCEDURE sp_WorkOrder_createAliquot
	@ParentSampleId INT,
	@Barcode NVARCHAR(100),
	@Volume NUMERIC(10, 2),
	@CreatedBy INT
AS
BEGIN

	INSERT Sample (
		Barcode,
		SampleTypeId,
		SampleFunctionId,
		InitialVolume,
		CurrentVolume,
		UnitOfMeasureId,
		StatusCode,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		Barcode = @Barcode,
		SampleTypeId = ps.SampleTypeId,
		SampleFunctionId = ps.SampleFunctionId,
		InitialVolume = @Volume,
		CurrentVolume = @Volume,
		UnitOfMeasureId = ps.UnitOfMeasureId,
		StatusCode = 'available',
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

	FROM		Sample PS
	WHERE		ps.Id = @ParentSampleId
		

END