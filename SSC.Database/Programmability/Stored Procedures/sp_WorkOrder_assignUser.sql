CREATE PROCEDURE sp_WorkOrder_assignUser
	@WorkOrderId INT,
	@UserId INT
AS
BEGIN

	UPDATE
		WorkOrder
	SET
		CurrentlyAssignedUserId = @UserId

	WHERE
		Id = @WorkOrderId

END