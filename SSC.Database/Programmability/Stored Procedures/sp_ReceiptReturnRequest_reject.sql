CREATE PROCEDURE sp_ReceiptReturnRequest_reject
	@ReceiptId INT,
	@RejectedBy INT
AS
BEGIN

	UPDATE
		ReceiptReturnRequest

	SET
		Rejected = 1,
		RejectedBy = @RejectedBy

	WHERE
		ReceiptId = @ReceiptId


	SELECT
		rrr.RequestedBy

	FROM		ReceiptReturnRequest RRR
	WHERE		rrr.ReceiptId = @ReceiptId

END