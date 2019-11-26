CREATE PROCEDURE sp_WorkOrder_cancel	
	@Id INT
AS
BEGIN

	DECLARE @CancelledStatusId INT

	SELECT @CancelledStatusId  = Id FROM WorkOrderStatus WHERE Code = 'cancelled'

	-- Cancel the work order
	UPDATE
		WorkOrder
	SET
		WorkOrderStatusId = @CancelledStatusId
	WHERE Id = @Id

	-- Release the samples
	UPDATE
		TBU
	SET
		StatusCode = 'available'
	FROM		Sample TBU
	INNER JOIN	WorkOrderParentSample WOPS
			ON	wops.SampleId = tbu.id
	WHERE		wops.WorkOrderId = @Id

END