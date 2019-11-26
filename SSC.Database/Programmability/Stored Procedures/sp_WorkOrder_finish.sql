CREATE PROCEDURE sp_WorkOrder_finish
	@WorkOrderId INT
AS
BEGIN

	DECLARE @FinishedStatusId INT

	SELECT @FinishedStatusId = Id FROM WorkOrderStatus WHERE Code = 'completed'

	UPDATE
		WorkOrder
	SET
		WorkOrderStatusId = @FinishedStatusId
	WHERE
		Id = @WorkOrderId

END