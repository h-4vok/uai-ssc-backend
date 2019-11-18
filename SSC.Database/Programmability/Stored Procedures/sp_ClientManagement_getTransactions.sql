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
		TransactionTypeCode = rt.Code,
		TransactionStatusCode = 
			CASE WHEN rt.Code = 'credit-note' THEN 'emitted'
			ELSE
				CASE WHEN rrr.Id IS NULL THEN 'finalized'
				ELSE
					CASE 
						WHEN rrr.Approved = 1 THEN 'return-approved'
						WHEN rrr.Rejected = 1 THEN 'finalized'
						ELSE 'return-requested'
					END
				END
			END
	FROM		ClientCompanyTransaction CCT

	LEFT  JOIN	Receipt R
			ON	cct.ReceiptId = r.Id

	LEFT  JOIN	ReceiptType RT
			ON	r.ReceiptTypeId = rt.Id

	INNER JOIN	TransactionType TT
			ON	cct.TransactionTypeId = tt.Id

	LEFT  JOIN	ReceiptReturnRequest RRR
			ON	r.Id = rrr.ReceiptId

	WHERE		cct.ClientId = @ClientId

	ORDER BY cct.Id DESC

END