CREATE PROCEDURE sp_ReceiptReturnRequest_getAll
AS
BEGIN

	SELECT 
		rrr.Id,
		ReceiptId = r.Id,
		r.ReceiptNumber,
		rrr.Approved,
		rrr.Rejected,
		ApprovedBy = pua.UserName,
		RejectedBy = pur.UserName,
		RequestedBy = purr.UserName,
		rrr.RequestDate,
		rrr.ReviewDate,
		RelatedCreditNoteNumber = cctrr.ReceiptNumber,
		RelatedCreditNoteId = cctrr.Id

	FROM		ReceiptReturnRequest RRR

	INNER JOIN	Receipt R
			ON	rrr.ReceiptId = r.Id

	LEFT  JOIN	PlatformUser PUA
			ON	pua.Id = rrr.ApprovedBy

	LEFT  JOIN	PlatformUser PUR
			ON	pur.Id = rrr.RejectedBy

	INNER JOIN	PlatformUser PURR
			ON	purr.Id = rrr.RequestedBy

	LEFT  JOIN	ClientCompanyTransaction CCTR
			ON	rrr.ReceiptId = cctr.RelatedReceiptId

	LEFT  JOIN	Receipt CCTRR
			ON	cctr.ReceiptId = cctrr.Id

	ORDER BY rrr.Id DESC

END