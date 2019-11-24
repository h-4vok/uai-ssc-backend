CREATE PROCEDURE sp_WorkOrder_addParentSample
	@SampleId INT,
	@WorkOrderId INT,
	@CreatedBy INT
AS
BEGIN

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