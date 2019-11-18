CREATE PROCEDURE sp_BillReturn_getDetail
	@ReceiptId INT
AS
BEGIN
	
	WITH CTE_ReceiptItemDescription AS (
		SELECT TOP 1
			rl.ReceiptId,
			Concept

		FROM		ReceiptLine RL

		WHERE		rl.ReceiptId = @ReceiptId
		AND			rl.Taxes > 0
	)
	SELECT
		r.ReceiptNumber,
		ItemDescription = id.Concept,
		TotalAmount = cct.Total

	FROM		Receipt R

	INNER JOIN	CTE_ReceiptItemDescription ID
			ON	r.Id = id.ReceiptId

	INNER JOIN	ClientCompanyTransaction CCT
			ON	r.Id = cct.ReceiptId

END