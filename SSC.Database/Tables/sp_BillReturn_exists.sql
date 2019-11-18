CREATE PROCEDURE sp_BillReturn_exists
	@ReceiptId INT
AS
BEGIN

	SELECT TOP 1 CONVERT(BIT, 1) FROM ReceiptReturnRequest RRR
	WHERE ReceiptId = @ReceiptId

END