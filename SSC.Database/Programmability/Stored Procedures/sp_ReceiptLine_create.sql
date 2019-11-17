CREATE PROCEDURE sp_ReceiptLine_create
	@ReceiptId INT,
	@Concept NVARCHAR(500),
	@Subtotal NUMERIC(10, 2),
	@Taxes NUMERIC(10, 2),
	@CreatedBy INT
AS
BEGIN

	INSERT ReceiptLine (
		ReceiptId,
		Concept,
		Subtotal,
		Taxes,
		CreatedBy,
		UpdatedBy
	)
	SELECT
		ReceiptId = @ReceiptId,
		Concept = @Concept,
		Subtotal = @Subtotal,
		Taxes = @Taxes,
		CreatedBy = @CreatedBy,
		UpdatedBy = @CreatedBy

END