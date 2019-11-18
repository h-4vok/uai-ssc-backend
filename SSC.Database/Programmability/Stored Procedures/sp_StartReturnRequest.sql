CREATE PROCEDURE sp_StartReturnRequest
	@ReceiptId INT,
	@RequestedBy INT
AS
BEGIN

	INSERT ReceiptReturnRequest (
		ReceiptId,
		RequestedBy
	)
	SELECT
		ReceiptId = @ReceiptId,
		RequestedBy = @RequestedBy

END