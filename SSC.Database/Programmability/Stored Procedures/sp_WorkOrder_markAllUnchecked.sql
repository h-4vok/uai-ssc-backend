CREATE PROCEDURE sp_WorkOrder_markAllUnchecked
	@WorkOrderId INT
AS
BEGIN

	UPDATE
		WorkOrderParentSample
	SET
		Checked = 0

	WHERE
		WorkOrderId = @WorkOrderId

END