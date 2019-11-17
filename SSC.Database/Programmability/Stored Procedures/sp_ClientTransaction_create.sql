CREATE PROCEDURE sp_ClientTransaction_create
	@TransactionTypeCode NVARCHAR(100),
	@Total NUMERIC(12, 2),
	@ClientId INT,
	@ReceiptId INT,
	@RelatedReceiptId INT = NULL
AS
BEGIN

	INSERT ClientCompanyTransaction (
		TransactionTypeId,
		Total,
		ClientId,
		ReceiptId,
		RelatedReceiptId
	)
	SELECT
		TransactionTypeId = tt.Id,
		Total = @Total,
		ClientId = @ClientId,
		ReceiptId = @ReceiptId,
		RelatedReceiptId = @RelatedReceiptId

	FROM		TransactionType TT
	WHERE		tt.Description = @TransactionTypeCode

	SELECT SCOPE_IDENTITY()

END