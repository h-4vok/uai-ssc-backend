CREATE PROCEDURE sp_Receipt_nullify
	@ReceiptId INT
AS
BEGIN

	UPDATE
		Receipt
	SET
		IsNullified = 1

	WHERE		Id = @ReceiptId

	SELECT ClientId FROM Receipt WHERE Id = @ReceiptId

END