CREATE PROCEDURE sp_ClientManagement_createFakeTransaction
	@TransactionDate SMALLDATETIME,
	@Total NUMERIC(12, 2),
	@ClientId INT
AS
BEGIN

	INSERT ClientCompanyTransaction (
		TransactionTypeId,
		TransactionDate,
		Total,
		ClientId
	)
	SELECT
		TransactionTypeId = tt.Id,
		TransactionDate = @TransactionDate,
		Total = @Total,
		ClientId = @ClientId

	FROM		TransactionType TT
	WHERE		tt.Description = 'Compra'

	SELECT SCOPE_IDENTITY()

END