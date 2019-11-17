CREATE PROCEDURE sp_ClientManagement_getTransactions
	@ClientId INT
AS
BEGIN

	SELECT
		TransactionId = cct.Id,
		ReceiptId = cct.ReceiptId,
		ReceiptNumber = r.ReceiptNumber,
		TransactionDescription = tt.Description,
		TransactionDate = cct.TransactionDate,
		Total = cct.Total,
		TransactionTypeCode = rt.Code

	FROM		ClientCompanyTransaction CCT

	LEFT  JOIN	Receipt R
			ON	cct.ReceiptId = r.Id

	LEFT  JOIN	ReceiptType RT
			ON	r.ReceiptTypeId = rt.Id

	INNER JOIN	TransactionType TT
			ON	cct.TransactionTypeId = tt.Id

	WHERE		cct.ClientId = @ClientId

	ORDER BY cct.TransactionDate DESC

END