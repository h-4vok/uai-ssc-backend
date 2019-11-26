CREATE PROCEDURE sp_WorkOrder_ToExecuting
	@WorkOrderId INT
AS
BEGIN

	DECLARE @StatusId INT

	SELECT @StatusId = Id FROM WorkOrderStatus WHERE Code = 'executing'

	UPDATE
		WorkOrder

	SET
		WorkOrderStatusId = @StatusId

	WHERE
		Id = @WorkOrderId

END