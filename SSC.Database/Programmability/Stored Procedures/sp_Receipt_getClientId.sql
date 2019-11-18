CREATE PROCEDURE sp_Receipt_getClientId
	@ReceiptId INT
AS
BEGIN

	SELECT ClientId FROM Receipt WHERE Id = @ReceiptId

END