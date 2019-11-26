CREATE PROCEDURE sp_WorkOrder_markChecked
	@WorkOrderId INT,
	@SampleId INT
AS
BEGIN

	UPDATE
		WorkOrderParentSample

	SET
		Checked = 1

	WHERE	
		WorkOrderId = @WorkOrderId
	AND
		SampleId = @SampleId

END