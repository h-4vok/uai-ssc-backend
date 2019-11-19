CREATE PROCEDURE sp_ClientManagement_getSelectableCreditNotes
	@ClientId INT
AS
BEGIN

	SELECT
		CreditNoteId = r.Id,
		CreditNoteNumber = r.ReceiptNumber,
		Amount = cct.Total

	FROM		Receipt R

	INNER JOIN	ReceiptType RT
			ON	r.ReceiptTypeId = rt.Id

	INNER JOIN	ClientCompanyTransaction CCT
			ON	cct.ReceiptId = r.Id

	WHERE		rt.Code = 'credit-note'
	AND			cct.ClientId = @ClientId
	AND			r.IsNullified = 0

END