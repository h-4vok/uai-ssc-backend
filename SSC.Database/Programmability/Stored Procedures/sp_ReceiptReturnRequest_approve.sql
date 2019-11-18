CREATE PROCEDURE sp_ReceiptReturnRequest_approve
	@ReceiptId INT,
	@ApprovedBy INT
AS
BEGIN

	UPDATE
		ReceiptReturnRequest

	SET
		Approved = 1,
		ApprovedBy = @ApprovedBy,
		ReviewDate = GETDATE()

	WHERE
		ReceiptId = @ReceiptId


	SELECT RequestedBy FROM ReceiptReturnRequest WHERE ReceiptId = @ReceiptId

END