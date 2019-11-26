CREATE PROCEDURE sp_WorkOrder_addParentSample
	@SampleId INT,
	@WorkOrderId INT,
	@CreatedBy INT
AS
BEGIN

	UPDATE
		Sample
	SET
		StatusCode = 'reserved'
	WHERE	Id = @SampleId

	INSERT WorkOrderParentSample (
		CreatedBy,
		SampleId,
		UpdatedBy,
		WorkOrderId
	)
	SELECT
		CreatedBy = @CreatedBy,
		SampleId = @SampleId,
		UpdatedBy = @CreatedBy,
		WorkOrderId = @WorkOrderId
		
END