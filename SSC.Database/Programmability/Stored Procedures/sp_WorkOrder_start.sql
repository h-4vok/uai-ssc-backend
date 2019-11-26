CREATE PROCEDURE sp_WorkOrder_start
	@OrderType NVARCHAR(100),
	@TenantId INT,
	@CreatedBy INT
AS
BEGIN

	DECLARE @WorkOrderStatusId INT
	DECLARE @WorkOrderTypeId INT

	SELECT @WorkOrderStatusId = Id  FROM WorkOrderStatus WHERE Code = 'checking'
	SELECT @WorkOrderTypeId = Id  FROM WorkOrderType WHERE Code = @OrderType

	INSERT WorkOrder (
		CreatedBy,
		RequestDate,
		TenantId,
		UpdatedBy,
		WorkOrderStatusId,
		WorkOrderTypeId
	)
	SELECT
		CreatedBy = @CreatedBy,
		RequestDate = GETDATE(),
		TenantId = @TenantId,
		UpdatedBy = @CreatedBy,
		WorkOrderStatusId = @WorkOrderStatusId,
		WorkOrderTypeId = @WorkOrderTypeId

	SELECT SCOPE_IDENTITY()

END